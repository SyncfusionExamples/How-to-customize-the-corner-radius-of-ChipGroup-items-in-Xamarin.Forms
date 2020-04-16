# ChipGroup-CornerRadius
This demo explains the way to customize the corner radius in ChipGroup.

[How to customize the corner radius of Chipgroup items in Xamarin](https://www.syncfusion.com/kb/11282/?utm_medium=listing&utm_source=github-examples)

To set CornerRadius value for each chipgroup items in the Xamarin ChipGroup([**SfChipGroup**](https://help.syncfusion.com/cr/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup.html)) by the following steps.

**Step 1:** Create a custom chipgroup class, which is derived from [SfChipGroup](https://help.syncfusion.com/cr/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup.html) **,** and define a property named CornerRadius.

**C#:**

```

public class CustomChipGroup : SfChipGroup
{
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create("CornerRadius", typeof(Thickness), typeof(CustomChipGroup), GetDefaultCornerRadius(), BindingMode.TwoWay, null, null);

    public Thickness CornerRadius
    {
        get { return (Thickness)GetValue(CornerRadiusProperty); }
        set { this.SetValue(CornerRadiusProperty, value); }
    }

    private static Thickness GetDefaultCornerRadius()
    {
        if (Device.RuntimePlatform == Device.Android)
        {
            return 40d;
        }

        return 15d;
    }
}

```

**Step 2:** Override the [**OnChildAdded**](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup~OnChildAdded.html) method and hook the [**ChildAdded**](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup~ChildAdded_EV.html) event in that method, which will be called whenever a new child is added to SfChipGroup. In that event method, you can set the value for CornerRadius for each individual [**SfChip**](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChip.html).

**C#:**

```

public class CustomChipGroup : SfChipGroup
{
    . . .
    protected override void OnChildAdded(Element child)
    {
        base.OnChildAdded(child);
        child.ChildAdded += Child_ChildAdded;
    }

    private void Child_ChildAdded(object sender, ElementEventArgs e)
    {
        var sfChip = e.Element as SfChip;
        if (sfChip != null)
        {
            sfChip.SetBinding(SfChip.CornerRadiusProperty, new Binding() { Path = "CornerRadius", Source = this, Mode = BindingMode.TwoWay });
        }
    }
}

```

**Step 3:** Unhook the [**ChildAdded**](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup~ChildAdded_EV.html) event in [**OnChildRemoved**](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Buttons.XForms~Syncfusion.XForms.Buttons.SfChipGroup~OnChildRemoved.html) override method.

**C#:**

```

public class CustomChipGroup : SfChipGroup
{
    . . .
    protected override void OnChildRemoved(Element child)
    {
        child.ChildAdded -= Child_ChildAdded;
        base.OnChildRemoved(child);
    }
}

```

**Step 4:** Set the CornerRadius value for customized SfChipGroup.

**XAML:**

```

<local:CustomChipGroup ItemsSource="{Binding Items}" 
                                              DisplayMemberPath="Name"     
                                              CornerRadius="0"/>

```

Also refer our [feature tour](https://www.syncfusion.com/xamarin-ui-controls/xamarin-chips) page to know more features available in our chips.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
