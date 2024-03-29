using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Practice_Window;

public static class PageAnimations
{
    public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
    {
        // Create the storyboard
        var sb = new Storyboard();

        // Add slide from right animation
        sb.AddSlideFromLeft(seconds, page.WindowWidth);

        // Add fade in animation
        sb.AddFadeIn(seconds);

        // Start animating
        sb.Begin(page);

        // Make page visible
        page.Visibility = Visibility.Visible;

        // Wait for it to finish
        await Task.Delay((int)(seconds * 1000));
    }

    public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
    {
        // Create the storyboard
        var sb = new Storyboard();

        // Add slide from right animation
        sb.AddSlideToRight(seconds, page.WindowWidth);

        // Add fade in animation
        sb.AddFadeOut(seconds);

        // Start animating
        sb.Begin(page);

        // Make page visible
        page.Visibility = Visibility.Visible;

        // Wait for it to finish
        await Task.Delay((int)(seconds * 1000));
    }


}