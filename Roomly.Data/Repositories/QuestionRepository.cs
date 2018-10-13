using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roomly.Data.Entities;

namespace Roomly.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly RoomlyContext _context;
        public QuestionRepository(RoomlyContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> Get()
        {
            return _context.Questions.ToList();
        }

        public Question Get(Guid id)
        {
            return _context.Questions.Find(id);
        }

        public Question Create(Question entity)
        {
            if (entity.QuestionId == Guid.Empty)
            {
                entity.QuestionId = Guid.NewGuid();
            }

            _context.Add(entity);
            _context.SaveChanges();
            return entity; 
        }

        public int Update(Question entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
