using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roomly.API.Contracts;
using Roomly.Business.Mappers;
using Roomly.Data.Repositories;

namespace Roomly.Business
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public List<Question> Get()
        {
            var models =  _repository.Get().Where(x => x.IsActive && !x.IsDeleted)
                .Select(x => x.ToModel())
                .ToList();
            return models;
        }

        public Question Get(Guid id)
        {
            var entity = _repository.Get(id);
            if (entity == null)
            {
                return null;
            }

            var model = entity.ToModel();
            return model;
        }

        public Question Create(Question model)
        {
            var entity = model.ToEntity();
            entity = _repository.Create(entity);
            return entity.UpdateModel(model);
        }

        public Question Update(Question model)
        {
            var entity = _repository.Get(model.QuestionId);
            if (entity == null)
            {
                return Create(model);
            }

            model.UpdateEntity(entity);
            _repository.Update(entity);
            return entity.UpdateModel(model);
        }
    }
}
