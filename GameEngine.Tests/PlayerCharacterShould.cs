using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        private const string Pattern = "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]";

        [TestMethod]
        public void BeInexperiancedWhenNew()
        {
            var sut = new PlayerCharacter();
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        public void NotHaveNickNameByDefault()
        {
            var sut = new PlayerCharacter();
            Assert.IsNull(sut.NickName);
        }
        [TestMethod]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();
            Assert.AreEqual(100, sut.Health);
        }      

        [DataTestMethod]
        //[DynamicData(nameof(Damages))]
        //[DynamicData(nameof(DamageData.GetDamages),DynamicDataSourceType.Method)]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData),typeof(ExternalHealthDamageTestData))]
        public void TakeDamage(int damage,int expectedHealth)
        {
            var sut = new PlayerCharacter();
            sut.TakeDamage(damage);
            Assert.AreEqual(expectedHealth, sut.Health);
        }
        [TestMethod]
        public void IncreaseAfterSleeping()
        {
            var sut = new PlayerCharacter();
            sut.Sleep();
            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }
        [TestMethod]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter();
            sut.FirstName = "Sasha";
            sut.LastName = "Mijalkovic";
            Assert.AreEqual("Sasha mijalkovic", sut.FullName,true);
        }

        [TestMethod]
        public void HaveFullNameStartsWithFirstName()
        {
            var sut = new PlayerCharacter();
            sut.FirstName = "Sasha";
            sut.LastName = "Mijalkovic";
            StringAssert.StartsWith(sut.FullName, "Sasha");
        }
        [TestMethod]
        public void HaveFullNameEndsWithLastName()
        {
            var sut = new PlayerCharacter();
            sut.FirstName = "Sasha";
            sut.LastName = "Mijalkovic";
            StringAssert.EndsWith(sut.FullName.ToLower(), "mijalkovic");
        }
        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            var sut = new PlayerCharacter();
            sut.FirstName = "Sasha";
            sut.LastName = "Mijalkovic";
            StringAssert.Matches(sut.FullName, new Regex(Pattern));
        }
        [TestMethod]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();
            CollectionAssert.Contains(sut.Weapons, "Long Bow");

        }
        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            var sut = new PlayerCharacter();
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }
        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();
            List<string> expectedWeapons = new List<string>()
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
            CollectionAssert.AreEqual(expectedWeapons,sut.Weapons);

        }
        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            var sut = new PlayerCharacter();
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKondOfSword()
        {
            var sut = new PlayerCharacter();
            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.ToLower().Contains("sword")));
        }
        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();
            Assert.IsTrue(sut.Weapons.Any(weapon => !string.IsNullOrWhiteSpace(weapon)));
        }


    }
}
 