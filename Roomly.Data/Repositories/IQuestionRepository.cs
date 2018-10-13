using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Roomly.Data.Entities;

namespace Roomly.Data.Repositories
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> Get();
        Question Get(Guid id);
        Question Create(Question entity);
        int Update(Question entity);
    }
}
