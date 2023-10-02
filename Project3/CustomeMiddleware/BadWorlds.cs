using System.Text;

namespace Project3.CustomeMiddleware
{
    public class BadWorlds
    {
        private readonly RequestDelegate _next;

        public BadWorlds(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST" && context.Request.Path == "/api/Message/CreateMessage")
            {
                string requestBody;
                using (var reader = new StreamReader(context.Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                if (ContainsBadWords(requestBody))
                {
                    await context.Response.WriteAsync("متن حاوی کلمات نامناسب است.");
                    return;
                }

                var newRequestBody = new MemoryStream();
                var newRequestBodyText = Encoding.UTF8.GetBytes(requestBody);
                await newRequestBody.WriteAsync(newRequestBodyText, 0, newRequestBodyText.Length);
                newRequestBody.Seek(0, SeekOrigin.Begin);
                context.Request.Body = newRequestBody;
            }

            await _next(context);
        }


        private bool ContainsBadWords(string text)
        {
            if (text.Contains("khar") || text.Contains("gav"))
            {
                return true;
            }

            return false;
        }
    }
}

