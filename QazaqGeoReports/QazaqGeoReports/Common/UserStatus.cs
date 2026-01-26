namespace QazaqGeoReports.Domain.Common;

public enum AvailabilityStatus
{
    Available = 1,       // Доступен
    Busy = 2,            // Занят
    InMeeting = 3,       // На совещании
    OnVacation = 4,      // В отпуске
    SickLeave = 5,       // Больничный
    BusinessTrip = 6,    // Командировка
    InField = 7,         // На объекте/в поле
    Remote = 8,          // Удалённо
    Offline = 9          // Не на связи
}
public enum EmploymentStatus
{
    Employed = 1,        // Работает
    Probation = 2,       // Испытательный срок
    OnHold = 3,          // Временно отстранён
    Resigned = 4,        // Уволился
    Terminated = 5       // Уволен
}