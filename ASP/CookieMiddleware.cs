namespace ASP
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {


            if (context.Request.Cookies.TryGetValue("LastInteractionTime", out string lastInteractionTime))
            {
                context.Items["LastInteractionTime"] = lastInteractionTime;
            }

            await _next(context);


        }
    }
}
