# Draft of V1

The following types are some of the first few being considered for XAML Standard 1.0. The list below shows some simple sample code that illustrates the usages and likely properties/methods/events on these types. 

This list will be updated with more types and more fleshed out specs will be added for each in the coming months. See what's additionally in plan for v1 and beyond in [proposals](https://github.com/Microsoft/xaml-standard/labels/proposal).

## 1. Button
```xml
   <Button x:Name="MyButton"
	   Content="My Button"
	   Click="MyButton_Click"
	   Command="{Binding MyButtonCommand}" />
```	
## 2. TextBlock
```xml
   <TextBlock x:Name="MyText"
	      Text="Hello World!"
	      Foreground="Blue"
	      HorizontalAlignment="Right"
	      VerticalAlignment="Top" />
```	
##	3. TextBox
```xml
   <TextBox x:Name="MyTextEntry"
	    Text="{Binding Path=Name, Mode=TwoWay}"
	    PlaceholderText="Enter your name"
	    AcceptsReturn="False"
	    TextChanged="MyTextEntry_TextChanged" />
```
##	4. ComboBox
```xml
   <ComboBox x:Name="MyComboBox"
	     ItemsSource="{Binding Items}"
	     SelectedIndex="0"
	     Foreground="Green"
	     SelectionChanged="MyComboBox_SelectionChanged" />
```	
##	5. Grid
```xml
   <Grid Background="Ivory">
      <Grid.RowDefinitions>
         <RowDefinition Height="50"/>
         <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <Grid.ColumnDefinitions>
         <ColumnDefinition Width="Auto" />
         <ColumnDefinition Width="*" />
      </Grid.ColumnDefinitions>
      <Button Grid.Row="1" Grid.Column="0" ... />
      ...
   </Grid>
```
##	6. StackPanel
```xml
   <StackPanel Orientation="Horizontal" Background="SkyBlue">
      <TextBlock Text="UserName: " />
      <TextBox PlaceholderText="Enter your username" />
   </StackPanel>
```	
##	7. Page
```xml
   <Page x:Class="MyNamespace.MyPage"
      Background="Beige">
      <Page.Content><!--optional-->
         <Grid ... />
      </Page.Content>
   </Page>
```
##	8. UserControl
```xml
   <UserControl x:Class="MyNamespace.MyPage">
      <UserControl.Content><!--optional-->
         <Grid ... />
      </UserControl.Content>
   </UserControl>
```	

In addition, the following properties should be available on all the types listed above:
* Margin : ` <Thickness ...> left,top,right,bottom </Thickness>`
* HorizontalAlignment : Center, Left, Right, Stretch
* VerticalAlignment : Center, Top, Bottom, Stretch
* Height 
* Width 

Controls like Button, TextBlock, TextBox and ComboBox will additionally allow the following properties:
* FontSize
* FontWeight : Bold, Normal
* FontStyle : Italic, Normal
* FontFamily
