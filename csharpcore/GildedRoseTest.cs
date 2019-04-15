using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private Item item = new Item { Name = "foo", SellIn = 25, Quality = 20 };
        private readonly List<Item> items;
        private readonly GildedRose app;

        public GildedRoseTest()
        {
            items = new List<Item>
            {
                item
            };
            app = new GildedRose(items);
        }

        [Fact]
        public void UpdateQuality_Lowers_Quality_By_1()
        {
            item.Quality = 10;

            app.UpdateQuality();

            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Lowers_Quality_By_2_After_SellByDate_Has_Passed()
        {
            item.Quality = 10;
            item.SellIn = -2;

            app.UpdateQuality();

            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Lowers_Quality_By_2_On_SellByDate()
        {
            item.SellIn = 0;
            item.Quality = 10;

            app.UpdateQuality();

            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Does_Not_Lower_Quality_Below_Zero()
        {
            item.Quality = 0;

            app.UpdateQuality();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Increases_Quality_By_1_For_Aged_Brie()
        {
            item.Name = "Aged Brie";
            item.Quality = 10;

            app.UpdateQuality();

            Assert.Equal(11, item.Quality);
        }

        //Quality of an item is never more than 50
        [Fact]
        public void UpdateQuality_Increases_Quality_No_More_Than_50()
        {
            item.Name = "Aged Brie";
            item.Quality = 50;

            app.UpdateQuality();

            Assert.Equal(50, item.Quality);
        }

        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [Fact]
        public void UpdateQuality_Does_Not_Change_Quality_For_Sulfuras()
        {
            item.Name = "Sulfuras, Hand of Ragnaros";
            item.Quality = 10;

            app.UpdateQuality();

            Assert.Equal(10, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Does_Not_Change_SellIn_For_Sulfuras()
        {
            item.Name = "Sulfuras, Hand of Ragnaros";
            item.SellIn = 10;

            app.UpdateQuality();

            Assert.Equal(10, item.SellIn);
        }

        /*"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert*/
    }
}