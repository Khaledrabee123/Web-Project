
//using LaptopShop.Views.viewmodels;
//using Microsoft.AspNetCore.Identity;

//namespace LaptopShop.Models.database
//{
//    public class UserRepo : IUserRepo
//    {
//        UserManager<User> UserManager;
//        DBlaptops DBlaptops;
//        laptopSetvice laptopSetvice;
//        public UserRepo(UserManager<User> UserManager, DBlaptops dBlaptops, laptopSetvice laptopSetvice)
//        {
//            this.UserManager = UserManager;
//            DBlaptops = dBlaptops;
//            this.laptopSetvice = laptopSetvice; 
//        }
//        public List<Laptop>GetLaptops(string username)
//        {

//          User x=   DBlaptops.Users.FirstOrDefault(e => e.UserName == username);
//            return x.Laptops.ToList();
//        }

//        public void Addlaptop(User User)
//        {
//            User x = UserManager.FindByIdAsync(User.Id);
            
//            x.Laptops.Add(laptopSetvice.getLaptopbyid(id));
//        }
//    }
//}
