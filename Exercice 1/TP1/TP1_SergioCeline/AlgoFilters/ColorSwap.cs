using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_SergioCeline.AlgoFilters
{
    public class ColorSwap : AlgoFilter
    {
        public ColorSwap() : base("Color swap") { }

        public override Bitmap algo(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);


            for (int i = 0; i < image.Width; i++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color c = image.GetPixel(i, x);
                    Color newColor = Color.FromArgb(c.A, c.G, c.B, c.R);
                    result.SetPixel(i, x, newColor);
                }

            }
            return result;
        }
        Here are some unit tests for the given algorithm:

1. Test if the algorithm returns the same image when given a blank image:
```csharp
[TestMethod]
public void TestAlgo_BlankImage()
        {
            // Arrange
            Bitmap blankImage = new Bitmap(100, 100);
            // Act
            Bitmap result = algo(blankImage);
            // Assert
            Assert.AreEqual(blankImage.Width, result.Width);
            Assert.AreEqual(blankImage.Height, result.Height);
            for (int i = 0; i < blankImage.Width; i++)
            {
                for (int x = 0; x < blankImage.Height; x++)
                {
                    Assert.AreEqual(blankImage.GetPixel(i, x), result.GetPixel(i, x));
                }
            }
        }
```

2. Test if the algorithm swaps the red and blue channels of a single pixel:
```csharp
[TestMethod]
public void TestAlgo_SinglePixel()
        {
            // Arrange
            Bitmap image = new Bitmap(1, 1);
            image.SetPixel(0, 0, Color.FromArgb(255, 10, 20, 30));
            // Act
            Bitmap result = algo(image);
            // Assert
            Assert.AreEqual(image.Width, result.Width);
            Assert.AreEqual(image.Height, result.Height);
            Assert.AreEqual(Color.FromArgb(255, 30, 10, 20), result.GetPixel(0, 0));
        }
```

3. Test if the algorithm swaps the red and blue channels of all pixels in a non-blank image:
```csharp
[TestMethod]
public void TestAlgo_NonBlankImage()
        {
            // Arrange
            Bitmap image = new Bitmap(2, 2);
            image.SetPixel(0, 0, Color.FromArgb(255, 10, 20, 30));
            image.SetPixel(1, 0, Color.FromArgb(255, 40, 50, 60));
            image.SetPixel(0, 1, Color.FromArgb(255, 70, 80, 90));
            image.SetPixel(1, 1, Color.FromArgb(255, 100, 110, 120));
            // Act
            Bitmap result = algo(image);
            // Assert
            Assert.AreEqual(image.Width, result.Width);
            Assert.AreEqual(image.Height, result.Height);
            Assert.AreEqual(Color.FromArgb(255, 30, 10, 20), result.GetPixel(0, 0));
            Assert.AreEqual(Color.FromArgb(255, 60, 40, 50), result.GetPixel(1, 0));
            Assert.AreEqual(Color.FromArgb(255, 90, 70, 80), result.GetPixel(0, 1));
            Assert.AreEqual(Color.FromArgb(255, 120, 100, 110), result.GetPixel(1, 1));
        }
    }
}
