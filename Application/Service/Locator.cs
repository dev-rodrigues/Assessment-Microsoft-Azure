using Application.Repository.Friendships;
using Application.Repository.Territory.Countries;
using Application.Repository.Territory.Friends;
using Application.Repository.Territory.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service {
    public class Locator {
        private static Dictionary<Type, Type> Country = new Dictionary<Type, Type> {
            [typeof(ICountry)] = typeof(CountryRepository)
        };

        private static Dictionary<Type, Type> State = new Dictionary<Type, Type> {
            [typeof(IState)] = typeof(StateRepository)
        };

        private static Dictionary<Type, Type> Friend = new Dictionary<Type, Type> {
            [typeof(IFriend)] = typeof(FriendRepository)
        };

        private static Dictionary<Type, Type> Friendships = new Dictionary<Type, Type> {
            [typeof(IFriendship)] = typeof(FriendshipRepository)
        };

        public static T GetInstanceOf<T>() {
            return Activator.CreateInstance<T>();
        }
    }
}
