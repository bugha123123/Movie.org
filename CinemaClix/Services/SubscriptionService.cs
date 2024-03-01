using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDBContext _appDBContext;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubscriptionService(AppDBContext appDBContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _appDBContext = appDBContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task AddSubscription(Subscriptions subscriptions,string type)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(CookieUserId, out int LoggedInUser))
            {
                var FoundUser = await _userService.GetUserById(LoggedInUser);
                var Subscriptions =  GetSubByPlanType(type);

                if (FoundUser != null)
                {
                    Subscriptions NewSubscription = new Subscriptions()
                    {
                        AddedBy = FoundUser.GmailAddress!,
                        PlanType = Subscriptions.PlanType,
                        SubscriptionPlanId = FoundUser.Id
                    };

                    await _appDBContext.Subscriptions.AddAsync(NewSubscription);
                    await _appDBContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("User not found for the given ID or SubscriptionPlans not found for the given PlanType");
                }
            }
            else
            {
                Console.WriteLine("Invalid UserId in the cookie");
            }
        }

        public async Task DeleteSubscriptionForUser(Subscriptions subscriptions)
        {
           
                var loggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

                if (int.TryParse(loggedInUser, out int userId))
                {
                    var foundUserInDb = await _userService.GetUserById(userId);

                    if (foundUserInDb != null)
                    {
                        var subscriptionToDelete = await _appDBContext.Subscriptions
                            .FirstOrDefaultAsync(s => s.AddedBy == foundUserInDb.GmailAddress);

                        if (subscriptionToDelete != null)
                        {
                            _appDBContext.Subscriptions.Remove(subscriptionToDelete);
                            await _appDBContext.SaveChangesAsync();

                        }
                       
                    }
               
                }
              
       
        
        }
   



        public SubscriptionPlans GetSubByPlanType(string PlanType)
        {
            SubscriptionPlans subscription = _appDBContext.SubscriptionPlans.FirstOrDefault(s => s.PlanType == PlanType)!;


            return subscription;
        }

        public async Task<List<SubscriptionPlans>> GetSubscriptionPlansList()
        {
            return await _appDBContext.SubscriptionPlans.ToListAsync();
        }

        public async Task<Subscriptions> GetSubscriptions()
        {
            var loggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(loggedInUser, out int userId))
            {
                var foundUserInDb = await _userService.GetUserById(userId);

                if (foundUserInDb != null)
                {
                    return await _appDBContext.Subscriptions
                        .FirstOrDefaultAsync(u => u.AddedBy == foundUserInDb.GmailAddress);
                }
            }

            throw new Exception("NO SUBSCRIPTIONS AVAILABLE");
        }

     

        public async Task<Subscriptions> GetSubscriptionsToCheckIfUserIsValidToAddSubscriptionAsync()
        {
            try
            {
                var loggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

                if (int.TryParse(loggedInUser, out int userId))
                {
                    var foundUserInDb = await _userService.GetUserById(userId).ConfigureAwait(false);

                    if (foundUserInDb != null)
                    {
                        return await _appDBContext.Subscriptions
                            .FirstOrDefaultAsync(s => s.AddedBy == foundUserInDb.GmailAddress)
                            .ConfigureAwait(false);
                    }
                }

                // Handle the case where user ID is not valid or user is not found
                return null;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Exception in GetSubscriptionsToCheckIfUserIsValidToAddSubscriptionAsync: {ex.Message}");
                throw; // Rethrow the exception for global error handling
            }
        }

    }
}
