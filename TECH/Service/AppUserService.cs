using Domain;
using Dto;
using Reponsitory;

namespace Service
{
    public interface IAppUserService
    {
        int CreateUser(AppUser appUser);
    }
    public class AppUserService : IAppUserService
    {

        private readonly IAppUserReponsitory _appUserReponsitory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public AppUserService(
            IAppUserReponsitory appUserReponsitory)
        {
            _appUserReponsitory = appUserReponsitory;
        }

        /// <summary>
        /// Get All Category
        /// <returns>List All CategoryModel from DB</returns>
        public int CreateUser(AppUser appUser)
        {
            var idUser = _appUserReponsitory.CreateUser(appUser);

            return idUser;
        }
    }
}