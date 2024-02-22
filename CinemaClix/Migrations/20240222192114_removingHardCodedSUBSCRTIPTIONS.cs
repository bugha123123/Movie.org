using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class removingHardCodedSUBSCRTIPTIONS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "SubscriptionPlansId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "SubscriptionPlansId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "SubscriptionPlansId",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "SubscriptionPlansId", "PlanPrice", "PlanType" },
                values: new object[,]
                {
                    { 1, "$9.99", "Basic" },
                    { 2, "$14.99", "Standard" },
                    { 3, "$19.99", "Premium" }
                });
        }
    }
}
