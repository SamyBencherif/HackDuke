using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Roomly.API.Contracts;

namespace Roomly.Business
{
    public interface IQuestionService
    {
        List<Question> Get();

        Question Get(Guid id);

        Question Create(Question model);

        Question Update(Question model);
    }
}
