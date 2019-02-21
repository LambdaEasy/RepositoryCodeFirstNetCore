using Lambda.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lambda.Domain
{
    [Table("Example")]
    public class Example : Entity<int>
    {
        #region Properties

        public string Name { get; set; }

        #endregion
    }
}
