   M S B A M L   `   `   `  ����G  CPetri.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Petri.Editor.ConverterPetri.Editor.Converter  5      E'clr-namespace:Petri.Editor.UI.ViewModelPetri.Editor.UI.ViewModel  5	      =#clr-namespace:Petri.Editor.ControlsPetri.Editor.Controls  5
      F BPetri.Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullT9clr-namespace:Petri.Logic.Components;assembly=Petri.LogicPetri.Logic.Components 5      S.clr-namespace:Petri.Editor.UI.View.Information Petri.Editor.UI.View.Information  5      *    $Petri.Editor.UI.View.EditorToolsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=18.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :	converter$clr-namespace:Petri.Editor.Converter     5      =	viewModel'clr-namespace:Petri.Editor.UI.ViewModel     5	      8controls#clr-namespace:Petri.Editor.Controls     5
      P
components9clr-namespace:Petri.Logic.Components;assembly=Petri.Logic     5      Finformation.clr-namespace:Petri.Editor.UI.View.Information     5      -   5          >�Name$
  self��5       � 	Resources 5      ,  &Petri.Editor.Converter.IsNullConverter   IsNullConverter5  /Petri.Editor.Converter.EnumDescriptionConverter  EnumDescriptionConverter S� 
MethodName S� 
ObjectType*   $Petri.Editor.UI.ViewModel.EditorMode  MyEnumValues S� MethodParameters M� TypeName �� 
TargetType �� Property �� Value��%,  &	        &	      &	 &     '	� �       5   
   6$     5   
   6-   S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ viewModel:EditorMode��6   5      �� 5   
   " 	�6   .�5      ��  � ��$ 5q�6'   �� 5       � ��
 �   �6+   5      5      ��5      �� 5   
   " >�6   .�5      ��  � {� . 6*   	 �� Triggers	 5      �� 5       
 �� Binding
 6   �� *	PnmlNet+ �� 	Converter# [   �� Value True6f   .a�5!      ��  � {� .  62   5"      5$      .��5'      �� $��10q�6   .+�5+   
   �� -   5         ��Name$ ListBoxTools��5+      ��6(   ��  �� Source# [  �� SelectedItem 6e   �� *
EditorMode+��5,      �� 5-      .R�5.      �� $��18(�6    ��6.   �� # [ 5/      51      �� 55   
    �� Orientation$ Vertical=�6   $��0,5,0,0q�6,   .+�57      �� -   5         ��Name$ 
ZoomSlider��57      $	��200��6)    � Minimum$
 0.25Q�58       � Value$ 1Q�59       � Maximum$	 1.5Q�5:       � SmallChange$	 0.5Q�5;       � LargeChange$	 1.0Q�5<      �� 5=      $��Center=�6   �� 5>      $�Zoom: ��6    �� 5?      �6   �� *Value+ �� ElementName$ 
ZoomSlider�� �� StringFormat$ p0��5@      5B      �� 5D   
    �� Padding$ 10q�6   $��0,15,0,0q�6   $��1q�60   ��6D   �� $ ListBoxTools�� �� Path$ BorderBrush���5E      �� 5F      " ��6   .�5G      ��  � y�$ 	Collapsed=�63   	 5H      ^� 5I       ^� 
Conditions 5J      �� 5K   "    �� Binding 6,   �� *CurrentInformationEntry+ �� UpdateSourceTrigger$ PropertyChanged=�# [   �� Value	 False6�   �� 5L   "    6,   �� *
EditorMode+$ PropertyChanged=� Edit6q   0�5N      �� 5O   "    � y�$ Visible=�6?   5Q      5T      ._�5W      �� $
��Left=�6   ��6:   �� *CurrentInformationEntry+ 5X       �� DataType'  !Petri.Logic.Components.Transition@   :Petri.Editor.UI.View.Information.TransitionInformationView  � DataContext"  Petri.Logic.Components.Place;   5Petri.Editor.UI.View.Information.PlaceInformationView��%�   (��       5Y   #   *, +)(�� F     5\   #   *, +)�� 5Y      "  6#   .R�5Z          6@   �� *.+5[      �� 5\      "  6#   .R�5]          6;   �� *.+5^      5_      5`      5b      5c      5g      