using Microsoft.AspNetCore.Mvc;
using HabitChallengeAPI.Models;

namespace HabitChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : ControllerBase
    {
        // Временная база данных (в памяти), чтобы не подключать SQL
        private static List<Challenge> _challenges = new List<Challenge>
        {
            new Challenge { Id = 1, Title = "Бег по утрам", StartDate = DateTime.Today, DoneDays = 3, TotalPlannedDays = 7 }
        };

        // GET: api/challenges (Получить все челленджи)
        [HttpGet]
        public ActionResult<IEnumerable<Challenge>> GetAll()
        {
            return Ok(_challenges);
        }

        // GET: api/challenges/1 (Получить один челлендж по ID)
        [HttpGet("{id}")]
        public ActionResult<Challenge> GetById(int id)
        {
            var challenge = _challenges.FirstOrDefault(c => c.Id == id);
            if (challenge == null) return NotFound("Челлендж не найден");
            return Ok(challenge);
        }

        // POST: api/challenges (Создать новый челлендж)
        [HttpPost]
        public ActionResult<Challenge> Create([FromBody] Challenge newChallenge)
        {
            // Простая логика: присваиваем ID и добавляем в список
            newChallenge.Id = _challenges.Count + 1;
            newChallenge.StartDate = DateTime.Today; // Старт сегодня

            _challenges.Add(newChallenge);

            // Возвращаем созданный объект (с рассчитанным процентом и датой окончания)
            return CreatedAtAction(nameof(GetById), new { id = newChallenge.Id }, newChallenge);
        }
    }
}