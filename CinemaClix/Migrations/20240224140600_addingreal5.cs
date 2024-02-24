using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class addingreal5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlanId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionPlanId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlanId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionPlansId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionPlansId",
                table: "Subscriptions",
                column: "SubscriptionPlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlansId",
                table: "Subscriptions",
                column: "SubscriptionPlansId",
                principalTable: "SubscriptionPlans",
                principalColumn: "SubscriptionPlansId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlansId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionPlansId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlansId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionPlanId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionPlanId",
                table: "Subscriptions",
                column: "SubscriptionPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlanId",
                table: "Subscriptions",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionPlans",
                principalColumn: "SubscriptionPlansId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
