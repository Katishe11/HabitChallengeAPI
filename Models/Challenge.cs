namespace HabitChallengeAPI.Models
{
    public class Challenge
    {
        public int Id { get; set; }// Название привычки
        public string Title { get; set; } = string.Empty; 
        public DateTime StartDate { get; set; } // Дата старта
        public DateTime EndDate => StartDate.AddDays(30); // Дата окончания (+30 дней)
        public int DoneDays { get; set; } // Сколько дней выполнено
        public int TotalPlannedDays { get; set; } // Сколько дней запланировано
        public double Percent => TotalPlannedDays == 0 ? 0 : (double)DoneDays / TotalPlannedDays * 100; // Процент прохождения
    }
}