using Roomly.API.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roomly.Business.Mappers
{
    public static class QuestionMapper
    {
        public static Data.Entities.Question ToEntity(this Question model)
        {
            Data.Entities.Question entity = new Data.Entities.Question();
            return model.UpdateEntity(entity);
        }

        public static Data.Entities.Question UpdateEntity(this Question model, Data.Entities.Question entity)
        {
            entity.QuestionId = model.QuestionId;
            entity.Title = model.Title;
            entity.Category = model.Category;
            entity.Body = model.Body;
            entity.ShortAnswer = model.ShortAnswer;
            entity.MultipleChoice = model.MultipleChoice;
            entity.TrueFalse = model.TrueFalse;
            entity.A = model.A;
            entity.B = model.B;
            entity.C = model.C;
            entity.D = model.D;
            entity.E = model.E;
            entity.Answer = model.Answer;
            entity.IsActive = model.IsActive;
            entity.IsDeleted = model.IsDeleted;

            return entity;
        }

        public static Question ToModel(this Data.Entities.Question entity)
        {
            Question model = new Question();
            return entity.UpdateModel(model);
        }

        public static Question UpdateModel(this Data.Entities.Question entity, Question model)
        {
            model.QuestionId = entity.QuestionId;
            model.Title = entity.Title;
            model.Category = entity.Category;
            model.Body = entity.Body;
            model.ShortAnswer = entity.ShortAnswer;
            model.MultipleChoice = entity.MultipleChoice;
            model.TrueFalse = entity.TrueFalse;
            model.A = entity.A;
            model.B = entity.B;
            model.C = entity.C;
            model.D = entity.D;
            model.E = entity.E;
            model.Answer = entity.Answer;
            model.IsActive = entity.IsActive;
            model.IsDeleted = entity.IsDeleted;

            return model;
            
        }
       
    }
}
