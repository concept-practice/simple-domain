using System.Collections.Generic;
using System.Linq;
using ApprovalTests;

namespace SimpleDomain.ApprovalTesting
{
    public static class ApprovalsHelper
    {
        public static string ApprovalsString(object obj)
        {
            return obj
                .GetType().GetProperties()
                .Aggregate(string.Empty, (final, property) => final + $"{property.Name}: {property.GetValue(obj)}\n");
        }

        public static IEnumerable<string> ApprovalsString(IEnumerable<object> objects)
        {
            return objects.Select(ApprovalsString);
        }

        public static void VerifyObject(object obj)
        {
            Approvals.Verify(ApprovalsString(obj));
        }

        public static void VerifyList(IEnumerable<object> objects)
        {
            Approvals.VerifyAll(ApprovalsString(objects), string.Empty);
        }
    }
}
