using System.Runtime.Serialization;

namespace BlazorLibrary
{
    [DataContract]
    public class BookData : IExtensibleDataObject
    {
        [DataMember]
        public string Title { get; set; } = "Unknown Title";
        [DataMember]
        public string Author { get; set; } = "Unknown Author";
        [DataMember]
        public bool IsRead { get; set; }
        [DataMember]
        public string? BackgroundColor { get; set; } // Optional: Specify a custom background color
        
        public ExtensionDataObject? ExtensionData { get; set; }

        public void GenerateRandomBackgroundColor()
        {
            var random = new Random();
            int red, green, blue;

            // Define ranges for gothic colors
            var colorCategory = random.Next(0, 4); // Choose between grays, dark greens, blues, and dark reds

            switch (colorCategory)
            {
                case 0: // Dark Grays
                    red = green = blue = random.Next(30, 100); // Keep RGB close and low for dark grays
                    break;
                case 1: // Dark Greens
                    red = random.Next(0, 50);    // Very low red
                    green = random.Next(30, 100); // Moderate green
                    blue = random.Next(0, 50);   // Very low blue
                    break;
                case 2: // Dark Blues
                    red = random.Next(0, 30);    // Very low red
                    green = random.Next(0, 30);  // Very low green
                    blue = random.Next(50, 120); // Low to moderate blue
                    break;
                case 3: // Dark Reds (Bordos)
                    red = random.Next(50, 120);  // Moderate red
                    green = random.Next(0, 30);  // Very low green
                    blue = random.Next(0, 30);   // Very low blue
                    break;
                default:
                    red = green = blue = 0; // Fallback to black
                    break;
            }

            BackgroundColor = $"rgb({red}, {green}, {blue})";
        }
    }
}