using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Practice_Window;

public static class StoryboardHelpers
{
    public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
    {
        // Create the margin animate from right 
        var animation = new ThicknessAnimation
        {
            Duration = new Duration(TimeSpan.FromSeconds(seconds)),
            From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
            To = new Thickness(0),
            DecelerationRatio = decelerationRatio
        };

        // Set the target property name
        Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

        // Add this to the storyboard
        storyboard.Children.Add(animation);
    }

    public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
    {
        // Create the margin animate from right 
        var animation = new ThicknessAnimation
        {
            Duration = new Duration(TimeSpan.FromSeconds(seconds)),
            From = new Thickness(0),
            To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
            DecelerationRatio = decelerationRatio
        };

        // Set the target property name
        Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

        // Add this to the storyboard
        storyboard.Children.Add(animation);
    }

    public static void AddFadeIn(this Storyboard storyboard, float seconds, bool from = false)
    {
        // Create the margin animate from right 
        var animation = new DoubleAnimation
        {
            Duration = new Duration(TimeSpan.FromSeconds(seconds)),
            To = 1,
        };

        // Animate from if requested
        if (from)
            animation.From = 0;

        // Set the target property name
        Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

        // Add this to the storyboard
        storyboard.Children.Add(animation);
    }

    public static void AddFadeOut(this Storyboard storyboard, float seconds)
    {
        // Create the margin animate from right 
        var animation = new DoubleAnimation
        {
            Duration = new Duration(TimeSpan.FromSeconds(seconds)),
            To = 0,
        };

        // Set the target property name
        Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

        // Add this to the storyboard
        storyboard.Children.Add(animation);
    }
}