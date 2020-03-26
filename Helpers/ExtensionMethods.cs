using System.Collections.Generic;
using System.Linq;
using Scm.Domain;

namespace Scm.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) {
            user.password = null;
            return user;
        }
    }
}