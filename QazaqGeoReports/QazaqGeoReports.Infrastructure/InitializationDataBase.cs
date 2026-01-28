using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QazaqGeoReports.Domain.Common; 
using QazaqGeoReports.Domain.Entities.Users;
using System.Text;

namespace QazaqGeoReports.Infrastructure;

public static class IdentitySeeder
{
    private const string DefaultPassword = "QG@Password123!";

    public static async Task SeedAllAsync(IServiceProvider sp)
    {
        var roleManager = sp.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = sp.GetRequiredService<UserManager<User>>();
        var db = sp.GetRequiredService<QazaqGeoReportContext>();

        await SeedRoles(roleManager);
        await SeedUsersAndJobs(userManager, db);
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        var roles = Enum.GetNames(typeof(Roles));
        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpperInvariant()
                });
            }
        }
    }

    private static async Task SeedUsersAndJobs(UserManager<User> userMgr, QazaqGeoReportContext db)
    {
        var now = DateTime.UtcNow;

        var seeds = GetSeeds();

        foreach (var s in seeds)
        {
            if (string.IsNullOrWhiteSpace(s.FullName)) continue;
             
            User? user = null;

            if (!string.IsNullOrWhiteSpace(s.PersonnelNumber))
            {
                var jobByTab = await db.UserJobs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.PersonnelNumber == s.PersonnelNumber);

                if (jobByTab != null)
                    user = await userMgr.FindByIdAsync(jobByTab.UserId);
            }
             
            if (user == null)
            {
                var (last, first, middle) = SplitFullName(s.FullName);

                var baseUsername = MakeUsernameSlug($"{last} {first} {middle}".Trim());
                var username = await EnsureUniqueUserName(userMgr, baseUsername, s.PersonnelNumber);

                user = await userMgr.FindByNameAsync(username);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = first,
                        LastName = last,
                        MiddleName = middle,

                        IsActive = false,
                        CreatedTime = now,
                        UpdatedTime = now,

                        UserName = username,
                        Email = $"{username}@qg.local",
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };

                    var res = await userMgr.CreateAsync(user, DefaultPassword);
                    if (!res.Succeeded)
                        throw new Exception($"Не удалось создать {s.FullName}: " +
                            string.Join("; ", res.Errors.Select(e => e.Description)));
                }
            }
             
            var role = GuessRoleFromTitle(s.JobTitle);
            if (string.Equals(user.Email, "mygoldencode@gmail.com", StringComparison.OrdinalIgnoreCase)
                   || string.Equals(user.UserName, "mygoldencode@gmail.com", StringComparison.OrdinalIgnoreCase)
                   || (user.FirstName == "Жангир" && user.LastName == "Емишов"))
            {
                role = Roles.Admin;
            }
            var existingJob = await db.UserJobs.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (existingJob == null)
            {
                db.UserJobs.Add(new UserJob
                {
                    UserId = user.Id,
                    JobTitle = s.JobTitle,
                    PersonnelNumber = s.PersonnelNumber,
                    Note = s.Note,
                    Role = role,
                    CreatedTime = now,
                    UpdatedTime = now
                });

                await db.SaveChangesAsync();
            }
            else
            {
                existingJob.JobTitle = s.JobTitle;
                existingJob.PersonnelNumber = s.PersonnelNumber;
                existingJob.Note = s.Note;
                existingJob.Role = role;  
                existingJob.UpdatedTime = now;

                await db.SaveChangesAsync();
            }
             
            var roleName = role.ToString();
            if (!await userMgr.IsInRoleAsync(user, roleName))
            {
                await userMgr.AddToRoleAsync(user, roleName);
            }
        }
    }

    // ---------------- helpers ----------------
    private static Roles GuessRoleFromTitle(string? jobTitle)
    {
        var t = (jobTitle ?? "").ToLowerInvariant();

        if (t.Contains("генеральный директор") || t.Contains("технический директор") ||
            t.Contains("финансовый директор") || t.Contains("заместитель генерального директора"))
            return Roles.General;

        if (t.Contains("водитель"))
            return Roles.Driver;

        if (t.Contains("рабочий") || t.Contains("техник") || t.Contains("повар"))
            return Roles.Worker;

        if (t.Contains("начальник") || t.Contains("руководитель") ||
            t.Contains("главный") || t.Contains("старший") || t.Contains("менеджер"))
            return Roles.Supervisor;

        return Roles.Worker;
    }
    private static (string last, string first, string middle) SplitFullName(string fullName)
    {
        var parts = (fullName ?? "")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (parts.Length == 0) return ("", "", "");
        if (parts.Length == 1) return (parts[0], "", "");
        if (parts.Length == 2) return (parts[0], parts[1], "");
        return (parts[0], parts[1], string.Join(' ', parts.Skip(2)));
    }

    private static string MakeUsernameSlug(string text)
    {
        var s = TransliterateToLatin(text).ToLowerInvariant();

        var sb = new StringBuilder();
        bool prevUnderscore = false;

        foreach (var ch in s)
        {
            if (char.IsLetterOrDigit(ch))
            {
                sb.Append(ch);
                prevUnderscore = false;
            }
            else if (!prevUnderscore)
            {
                sb.Append('_');
                prevUnderscore = true;
            }
        }

        var res = sb.ToString().Trim('_');
        while (res.Contains("__")) res = res.Replace("__", "_");
        return string.IsNullOrWhiteSpace(res) ? "user" : res;
    }

    private static async Task<string> EnsureUniqueUserName(UserManager<User> userMgr, string baseUserName, string? personnelNumber)
    {
        var candidate = baseUserName;
         
        if (await userMgr.FindByNameAsync(candidate) == null)
            return candidate;
         
        if (!string.IsNullOrWhiteSpace(personnelNumber))
        {
            candidate = $"{baseUserName}_{personnelNumber}";
            if (await userMgr.FindByNameAsync(candidate) == null)
                return candidate;
        }
         
        var i = 1;
        while (true)
        {
            candidate = $"{baseUserName}_{i}";
            if (await userMgr.FindByNameAsync(candidate) == null)
                return candidate;
            i++;
        }
    }

    private static string TransliterateToLatin(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        var map = new Dictionary<char, string>
        {
            // RU
            ['а'] = "a",
            ['б'] = "b",
            ['в'] = "v",
            ['г'] = "g",
            ['д'] = "d",
            ['е'] = "e",
            ['ё'] = "yo",
            ['ж'] = "zh",
            ['з'] = "z",
            ['и'] = "i",
            ['й'] = "y",
            ['к'] = "k",
            ['л'] = "l",
            ['м'] = "m",
            ['н'] = "n",
            ['о'] = "o",
            ['п'] = "p",
            ['р'] = "r",
            ['с'] = "s",
            ['т'] = "t",
            ['у'] = "u",
            ['ф'] = "f",
            ['х'] = "kh",
            ['ц'] = "ts",
            ['ч'] = "ch",
            ['ш'] = "sh",
            ['щ'] = "shch",
            ['ъ'] = "",
            ['ы'] = "y",
            ['ь'] = "",
            ['э'] = "e",
            ['ю'] = "yu",
            ['я'] = "ya",
            // KZ
            ['ә'] = "a",
            ['ғ'] = "g",
            ['қ'] = "k",
            ['ң'] = "n",
            ['ө'] = "o",
            ['ү'] = "u",
            ['ұ'] = "u",
            ['һ'] = "h",
            ['і'] = "i"
        };

        var sb = new StringBuilder(input.Length * 2);
        foreach (var c in input)
        {
            var lower = char.ToLowerInvariant(c);
            if (map.TryGetValue(lower, out var repl)) sb.Append(repl);
            else sb.Append(c);
        }
        return sb.ToString();
    }

    private record UserSeed(string JobTitle, string FullName, string? PersonnelNumber, string? Note);

    private static List<UserSeed> GetSeeds() => new()
    {
        // Аппарат управления
        new("Генеральный директор","Аукешев Бекасыл Капбасович","133252","совместитель"),
        new("Заместитель генерального директора","Есимханова Нурганым Даулетбековна","137740","с 12.12.2025г."),
        new("Технический директор","Инкин Дмитрий Анатольевич","145635",null),
        new("Финансовый директор","Ниценко Ирина Владимировна","142720","совместитель"),
        new("Главный инженер по QA/QC","Сыздыханов Адильхан Сейсенбаевич","140542",null),
        new("Главный бухгалтер","Оразбаева Галия Кабикеновна","141352",null),
        new("Старший бухгалтер","Жонкина Мадина Ерболовна","150047",null),
        new("Бухгалтер","Батырбай Гульшат Батырбаевна","44165-2","с 21.07.2025г."),
        new("Заведующий складом","Дакеева Салтанат Айтмагамбетовна","143086","совместитель"),

        // Планово-экономический отдел
        new("Начальник отдела","Серік Ермұхаммет Амангелдіұлы","127915",null),
        new("Ведущий экономист","Базылова Жанар Абдрахмановна","83132",null),
        new("Ведущий экономист","Булекпаева Жанар Кабдулакызы","149753","с 13.11.2024г."),

        // HR
        new("Главный HR-менеджер","Бейлова Нургуль Омаровна","144001","с 01.07.2024г."),
        new("HR-менеджер","Жұбан Данель Еслбаевна","134873","д/о"),
        new("HR-менеджер","Омарова Меруерт Кыдырбеккызы","44850","вместо д/о"),

        // Эксплуатация/обслуживание
        new("Главный механик","Серікұлы Ерасыл","136071","с 01.03.2024г."),
        new("Инженер производственного обеспечения","Түгелбай Абылай Әбусағитұлы","136072",null),
        new("Старший механик","Сулейменов Рахман Женисович","148689","с 27.05.2024г."),

        // Водители
        new("Водитель автомобиля","Курманбаев Алмас Ерланович","148994","с 29.07.2024г."),
        new("Водитель автомобиля (сезонник)","Куншеев Адилет Асанович","143377","с 01.07.2024г."),
        new("Водитель автомобиля (сезонник)","Орманбетов Ербол Капиятулы","146377","с 01.07.2024г."),
        new("Водитель автомобиля (сезонник)","Куанышбаев Габит Уташович","146378","с 01.07.2024г."),
        new("Водитель автомобиля (сезонник)","Абдрахманов Ермек Таутебайулы","147549","с 01.07.2024г."),
        new("Водитель автомобиля (сезонник)","Алипов Манас Сундетович","133171","с 01.07.2024г."),
        new("Водитель автомобиля (сезонник)","Рахатов Ермек Хабибуллинович","150455","с 17.05.2025г."),
        new("Водитель автомобиля (сезонник)","Мукушев Жангелды Зарубекович","150464","с 22.05.2025г."),
        new("Водитель автомобиля (сезонник)","Мукажанов Жангазы Кауазович","150648","с 18.06.2025г."),
        new("Водитель автомобиля (сезонник)","Букеев Рустем Карибаевич","150949",null),

        // Аэрогеофизика
        new("Геофизик 1 категории","Жармұқаш Мерей Жұмағазыұлы","140160",null),

        // Камеральные работы
        new("Ведущий геофизик","Кравцов Артем Александрович","140164",null),
        new("Геофизик 1 категории","Маматов Елжас Мақсұтұлы","143786",null),
        new("Ведущий геодезист","Присяжнюк Алексей Николаевич","138063",null),
        new("Ведущий геолог","Тарасов Игорь Александрович","145110",null),
        new("Менеджер по проекту","Кумболатова Гульдана Бауыржановна","140943",null),

        // Лаборатория
        new("Руководитель лаборатории","Игнатович Александр Викторович","139985",null),

        // Электроразведка
        new("Ведущий геофизик","Бандалетов Александр Валерьевич","140162",null),
        new("Ведущий геофизик","Ким Борис Владиславович","140159",null),
        new("Ведущий геофизик","Куспеков Алмас Бауыржанович","140158","с 03.06.2024"),
        new("Геофизик 2 категории (на обработку)","Мырзабаев Жанторе Жоламанулы","140855",null),
        new("Геофизик 2 категории (на обработку)","Султанов Зариф Фирхатович","140581",null),
        new("Геофизик 3 категории (оператор)","Красин Владимир Евгеньевич","140328","с 01.08.2025г."),
        new("Геофизик 3 категории (оператор)","Жумабаев Бекзат Адилевич",null,"с 24.09.2025г."),
        new("Геофизик 3 категории (оператор)","Батурханов Султан Арманұлы","143243","с 22.12.2025г."),

        new("Техник на обеспечение (сезонник)","Ахметбаев Арсен Манарбекович","143548","с 02.08.2024г."),
        new("Техник на обеспечение (сезонник)","Байгабулов Дастан Асетович","143245",null),
        new("Техник на обеспечение (сезонник)","Усенов Нұрасыл Сырымұлы","143133","с 01.04.2025г."),
        new("Техник на обеспечение (сезонник)","Файзуллов Мади Болатович","143244",null),

        new("Рабочий на геофизических работах","Ораз Жақып Сәбитұлы","146442",null),
        new("Рабочий на геофизических работах","Қазбек Нұрдәулет Аманғазыұлы","149273","с 09.09.2024г."),
        new("Рабочий на геофизических работах","Құрмантаев Тұмар Ғизатұлы","143032","с 09.09.2024г."),
        new("Рабочий на геофизических работах","Сапаралы Еркебұлан Ерланұлы","149069","с 26.05.2025г."),

        new("Повар","Оразбаева Бибигуль Мухановна","150511","с 02.05.2025г."),

        // Магниторазведка
        new("Геофизик 2 категории (на обработку)","Жанен Абай Ғалымжанұлы","140447",null),
        new("Геофизик 2 категории (на обработку)","Букпанов Рауан Амитович","141977","с 01.07.2024г."),
        new("Техник на обеспечение (сезонник)","Ильяс Диас Даниярұлы","143444",null),
        new("Техник на обеспечение (сезонник)","Болатбеков Аян Тлеубекович","143031-2",null),
        new("Техник на обеспечение (сезонник)","Саимов Адиль Асетович","142821-2",null),
        new("Техник на обеспечение (сезонник)","Жакенов Оразбек Тлеубекович","142823",null),
        new("Техник на обеспечение (сезонник)","Азтаев Азамат Кайратович","147441","с 02.08.2024г."),

        // Спектрометрия
        new("Техник на обеспечение","Абиев Абылайхан Азаматович","150694",null),

        // Топографо-геодезическая служба
        new("Геодезист 1 категории","Авняков Андрей Динарович","140579",null),
        new("Геодезист 1 категории","Грицкевич Антон Николаевич","142188",null),
        new("Геодезист 1 категории","Кумысбеков Жаныбек Аманбекович","140946",null),
        new("Геодезист 2 категории (сезонник)","Аубакиров Алишер Солтанович","142158",null),
        new("Геодезист 2 категории (сезонник)","Бағдат Диас Нұрланұлы",null,null),
        new("Рабочий на геофизических работах","Төлеу Үміт Төлеуқызы",null,"с 10.11.2025г."),
        new("Рабочий на геофизических работах", "Емишов Жангир Бауржанович", null, "с 28.07.2025г."),

        // Маркшейдерская служба
        new("Маркшейдер I категории","Есенбаев Абзал Майрамбекович","144891",null),
        new("Маркшейдер на обработку","Шерубаев Санжар Саулетович","141696","с 01.09.2024г."),

        // ГИС
        new("Геофизик оператор ГИС","Тұрар Нұрсұлтан Сәкенұлы","141168",null),
        new("Геофизик оператор ГИС","Дроздов Александр Вячеславович","142654","с 16.09.2023"),
        new("Геофизик оператор ГИС","Берикулы Данияр","150742","с 14.07.2025"),
        new("Геофизик оператор ГИС","Жасымбек Мирас Әділбекұлы","141979","с 01.03.2024"),

        new("Водитель автомобиля","Байтемиров Сайран Сайлауович","142463",null),
        new("Водитель автомобиля","Оспанов Серикбай Жетписбаевич","142735","с 16.09.2024г."),
        new("Водитель автомобиля","Шукманов Жаркын Женисулы","146441","с 12.07.2023г.")
    };
}
