   M S B A M L   `   `   `  ����G  CPetri.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Petri.Editor.UI.View.Information Petri.Editor.UI.View.Information  5      =#clr-namespace:Petri.Editor.ControlsPetri.Editor.Controls  5      @    :Petri.Editor.UI.View.Information.TransitionInformationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=18.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Petri.Editor.UI.View.Information     5      8controls#clr-namespace:Petri.Editor.Controls     5      .��5
      �� $
��Left=�6   .+�5   
   �� $
��Name��6   $
��Left=�6   �� 5   
     �� 	MaxLength$  40��6   $��3q�6!   $	��250��6-   $
��Left=�69   ��5      �� *
NameBind+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5   
    �� Orientation$ 
Horizontal=�6   $��0,8,0,0q�6.   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��X:��6   $
��Left=�6%   *  $Petri.Editor.Controls.NumericTextBox  5         MaxValue$
 8000��6*   $  5��6:   $��3q�6H   $��50��6T   $
��Left=�6_   ��5   *   �� *
Position.X+$ PropertyChanged=�$ TwoWay=�5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Y:��6   $
��Left=�6%     5      $
 8000��6*   $  5��6:   $��3q�6H   $��50��6T   $
��Left=�6_   ��5   *   �� *
Position.Y+$ PropertyChanged=�$ TwoWay=�5      5      �� 5   
   $
��Left=�6   $��Beschreibung��6,   �� 5   
   $
  1500��6   $��3q�6#   " �� VerticalScrollBarVisibility$
 Auto=�5       �� AcceptsReturn . $	��250��5      $
��Left=�6   $	��500��69    �� TextWrapping$
 Wrap=�5      $	��300��6&   ��5      �� *Description+$ PropertyChanged=�$ TwoWay=�5       5!      