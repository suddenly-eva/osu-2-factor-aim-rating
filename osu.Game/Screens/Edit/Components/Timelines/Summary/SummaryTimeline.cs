// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Screens.Edit.Components.Timelines.Summary.Parts;

namespace osu.Game.Screens.Edit.Components.Timelines.Summary
{
    /// <summary>
    /// The timeline that sits at the bottom of the editor.
    /// </summary>
    public class SummaryTimeline : CompositeDrawable
    {
        private const float corner_radius = 5;
        private const float contents_padding = 15;

        public Bindable<WorkingBeatmap> Beatmap = new Bindable<WorkingBeatmap>();

        private readonly Drawable background;

        private readonly Drawable timelineBar;

        public SummaryTimeline()
        {
            Masking = true;
            CornerRadius = corner_radius;

            TimelinePart markerPart, controlPointPart, bookmarkPart, breakPart;

            InternalChildren = new[]
            {
                background = new Box { RelativeSizeAxes = Axes.Both },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding { Left = contents_padding, Right = contents_padding },
                    Children = new[]
                    {
                        markerPart = new MarkerPart { RelativeSizeAxes = Axes.Both },
                        controlPointPart = new ControlPointPart
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.BottomCentre,
                            RelativeSizeAxes = Axes.Both,
                            Height = 0.35f
                        },
                        bookmarkPart = new BookmarkPart
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.TopCentre,
                            RelativeSizeAxes = Axes.Both,
                            Height = 0.35f
                        },
                        timelineBar = new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                new Circle
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreRight,
                                    Size = new Vector2(5)
                                },
                                new Box
                                {
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    RelativeSizeAxes = Axes.X,
                                    Height = 1,
                                    EdgeSmoothness = new Vector2(0, 1),
                                },
                                new Circle
                                {
                                    Anchor = Anchor.CentreRight,
                                    Origin = Anchor.CentreLeft,
                                    Size = new Vector2(5)
                                },
                            }
                        },
                        breakPart = new BreakPart
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Height = 0.25f
                        }
                    }
                }
            };

            markerPart.Beatmap.BindTo(Beatmap);
            controlPointPart.Beatmap.BindTo(Beatmap);
            bookmarkPart.Beatmap.BindTo(Beatmap);
            breakPart.Beatmap.BindTo(Beatmap);
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            background.Colour = colours.Gray1;
            timelineBar.Colour = colours.Gray5;
        }
    }
}