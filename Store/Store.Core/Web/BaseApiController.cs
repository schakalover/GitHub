using Microsoft.AspNetCore.Mvc;
using Store.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Web
{
    public class BaseApiController : ControllerBase
    {
        protected virtual ActionResult CreateStringErrorMessage(bool success, string message, int statusCode)
        {
            var result = new ObjectResult(new { success = success, error_code = statusCode, error_msg = message.ToUpper() });
            result.StatusCode = statusCode;
            return result;
        }

        protected virtual async Task<ActionResult> HandleOperationExecutionAsync(Func<Task<ActionResult>> operationBody)
        {
            try
            {
                var response = await operationBody();

                return response;
            }
            catch (BadRequestException ex)
            {
                return CreateStringErrorMessage(false, ex.Message, (int)HttpStatusCode.BadRequest);
            }
            catch (RecordNotFoundException ex)
            {
                return CreateStringErrorMessage(false, ex.Message, (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CreateStringErrorMessage(false, ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
