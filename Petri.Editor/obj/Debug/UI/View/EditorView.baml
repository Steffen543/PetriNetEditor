   M S B A M L   `   `   `  ����F  BPetri.Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullT9clr-namespace:Petri.Logic.Components;assembly=Petri.LogicPetri.Logic.Components  5      G CPetri.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Petri.Editor.ConverterPetri.Editor.Converter 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      ?$clr-namespace:Petri.Editor.ConverterPetri.Editor.Converter 5      U QGongSolutions.WPF.DragDrop, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop 5      E'clr-namespace:Petri.Editor.UI.ViewModelPetri.Editor.UI.ViewModel 5      I)clr-namespace:Petri.Editor.Converter.ConnPetri.Editor.Converter.Conn 5      1clr-namespace:Petzold.Media2DPetzold.Media2D 5      =#clr-namespace:Petri.Editor.ControlsPetri.Editor.Controls 5      ;"clr-namespace:Petri.Editor.UI.ViewPetri.Editor.UI.View 5      %   Petri.Editor.UI.View.EditorView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=18.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      P
components9clr-namespace:Petri.Logic.Components;assembly=Petri.Logic     5      ;
converters$clr-namespace:Petri.Editor.Converter     5      9system&clr-namespace:System;assembly=mscorlib     5	      c	 _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 5
      4	converter$clr-namespace:Petri.Editor.Converter 	 5      UddLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop 	 5      7	viewModel'clr-namespace:Petri.Editor.UI.ViewModel 	 5      CconverterConnection)clr-namespace:Petri.Editor.Converter.Conn 	 5      +media2dclr-namespace:Petzold.Media2D 	 5      2controls#clr-namespace:Petri.Editor.Controls 	 5      -view"clr-namespace:Petri.Editor.UI.View 	 5      -   5          >�Name$
  self��5        � 	Resources 5      , &Petri.Editor.Converter.IsNullConverter   IsNullConverter2 ,Petri.Editor.Converter.IsEditorModeConverter  IsEditorModeConverter0 *Petri.Editor.Converter.PercentageConverter  PercentageConverter. (Petri.Editor.Converter.IsBiggerConverter  IsBiggerConverter9  3Petri.Editor.Converter.PetriNetCoordinatesConverter   PetriNetCoordinatesConverter, &Petri.Editor.Converter.EqualsConverter  EqualsConverter   EditorViewModel �� ElementName �� Path4 .Petri.Editor.Converter.IncreaseNumberConverter  IncreaseNumberConverter5 /Petri.Editor.Converter.EnumDescriptionConverter  EnumDescriptionConverter5	 /Petri.Editor.Converter.ConnectionColorConverter  ConnectionColorConverter S� 
MethodName S� 
ObjectType*
  $Petri.Editor.UI.ViewModel.EditorMode 	 MyEnumValues S� MethodParameters M� TypeName4 .Petri.Editor.Converter.Conn.HalfValueConverter 
 HalfValueConverter	 �� 
TargetType  Border_UI_Placeable  Border_Stelle
 �� BasedOn �� Property �� Value  Border_Transition  NetObjectSize��%"  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 �     &	 �     &	 �     &		 �     &	
 G    &	 Z    &	 {    7  &	 �    7    5   
   6$     5   
   6*     5   
   6(     5   
   6&     5   
   61     5   
    6$   �� $
 self��$ DataContext�6c     5   
   6,     5   
   6-   	  5   
   6-   S� 5   
   $ 	GetValues��6   " 
 64    5      M� 5       $ viewModel:EditorMode��6   5"        5#   
   61   �� 5$   
   "	 ��6   5&      �� 5'   
   "	 ��6   8
   .�5(      ��  �@��CornerRadius$ 50��6-   �� 5)       � ��
 �����6+   5+      �� 5,   
   "	 ��6   8
   .�5-      ��  � ��
 ��  �6+   �� 5.       � ��# �  6&   �� 5/       � ��# �  6'   50      51      .��52      �  � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $��* �6   �� 56      $
��Auto �6   .+�5:   
   �� -   5         ��Name$ MainScrollViewer��5:   p   $��Visible=�6   $��1��6?   $
��Auto=�6M   ��5;      �� 5<      "	 ��6    �� Triggers 5=      �� 5>       �� Binding 6&   �� *	PnmlNet+ �� 	Converter# [   �� Value True6n   .a�5?      ��  � y�$ 	Collapsed=�6;   6O   5@      5B      .��5D      �� -   5         ��Name$ MainItemsControl��5D   �   )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget . $
��8100��6_   $
��8100��6l   $��1��6z   ���#A0A0A0   DropHandler 6   �� ��6�   �� $ PnmlNet.PetriNet.Objects� � LayoutTransform 5E      �� 5F      -   5        ScaleTransform��5F   %   . 	 (System.Windows.Interactivity.Interaction   Triggers 5H      / 	 )System.Windows.Interactivity.EventTrigger  5I         	EventName$ MouseLeftButtonUp��6%   . 	 (System.Windows.Interactivity.TriggerBase   Actions. 5J      6 	 0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *DataContext.AddCommand+$
 self��   CommandParameter 6m   �� $ MainItemsControl��# [  �� UpdateSourceTrigger$ PropertyChanged=�5K      ��5M      �� 5N      .R�5O      ��  ��Name$ 
MainCanvas��6!   $��Stretch=�65   $��Stretch=�6S   5P      ��5R      �� 5S      "	 ��6   .�5T      ��  �@��Left 68   �� *
Position.X+$ PropertyChanged=��� 5U       �@��Top 67   �� *
Position.Y+$ PropertyChanged=�5V       5X       �� DataType'   !Petri.Logic.Components.Connection  Petzold.Media2D.ArrowLine  Name#  Petzold.Media2D.ArrowLineBase    IsArrowClosed!   ArrowLength	"   X1	#   Y1	$   X2	%   Y2& ^� 
Conditions' �� Binding( �� RelativeSource) �� Value
* �� Top+ �� Left6  0Petri.Editor.Controls.EditConnectionValueControl, � DataContext'   !Petri.Logic.Components.Transition- ��Name. J� OpacityMask/ !� Visual-  'Petri.Editor.Controls.ConnectableButton0  Name1   
EditorMode  ConnectableButtonStyle"   Petri.Logic.Components.Place2 �� CornerRadius3   CornerRadius'   !Petri.Logic.Components.PlacePoint4 �� ConverterParameter��%)'  (��       5Y   #   *, +)(��     5�   #   *, +)7  7  7   7   7   (�� |    5  $   *, +)7  7  7  7  7  7   7   7   �� 5Y      "  6#   .R�5Z      �� ._�5[      �� 
���  ��.+�5\   "     $ Arrow��64     . $��2��5]   %   $! 17Q�69   " 5^   %   �� *SourcePosition.X+$ PropertyChanged=�# 5_   %   �� *SourcePosition.Y+$ PropertyChanged=�$ 5`   %   �� *DestinationPosition.X+$ PropertyChanged=�% 5a   %   �� *DestinationPosition.Y+$ PropertyChanged=� 5c   &     5d   *   $ MouseLeftButtonUp��69   . 5e   .      6D   �� *DataContext.DeleteCommand+$
 self�� 6�   �� *.+5f   +   ��5h   &   �� 5i   *   "	  60   .�5j   .   ��  � �� �#2121216G   �� 5k   .    � �� �#2121216E    5l   .   ^� 5p   2   & 5q   6   �� 5r   :   ' 6D   �� $ IsMouseOver�( �� *Self+) true6�   �� 5s   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�
) Delete6�   0�5u   6   �� 5v   :    � ��
 �  ��6S   �� 5w   :    � ��
 �  ��6Q   �� 5x   :    �@�Cursor$
 Hand��6S   5z   3   ^� 5{   2   & 5|   6   �� 5}   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) Execute6�   �� 5~   :   ' 6D   �� *IsExecutable+$ PropertyChanged=�) True6�   0�5�   6   �� 5�   :    � ��
 � � �6S   �� 5�   :    � ��
 � � �6Q   5�   3   5�   +   5�   #   �� 5�   "   * 6*   �� $ Arrow��$ MiddlePoint.Y�+ 5�   $   �� $ Arrow��$ MiddlePoint.X�._�5�   &     , 6J   �� *.+5�   #   5�      5�      5�      �� 5�      "  6#   .R�5�      �� $- 
MainBorder��6!   $��5q�65   ��5�      �� 5�   "   "	 ��6(    5�   &   �� 5�   *    66   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� Edit6�   .a�5�   .   ��  �@ IsDragSource . 6Y   5�   +   5�   #   ._�5�      � . 5�   "   !� 5�   &   / 62   �� $ 
BorderMain��.+�5�   "   �� $- 
BorderMain��6T   8��    5�   "   $0 
MainButton��6=   1 6R   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� 5�   &   ���� 5�   *   '        "	  60   8
  .�5�   .   ��  � �� 6H   �� *
NameBind+$ PropertyChanged=� 5�   .   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� *SelectedAsSource+$ PropertyChanged=�) True6�   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   0�5�   6   �� 5�   :    �@ IsMarkedAsSource . 6]   5�   3   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) Execute6�   �� 5�   :   ' 6D   �� *IsExecutable+$ PropertyChanged=�) true6�   0�5�   6   �� 5�   :    �@ IsExecutable . 6Y   �� 5�   :    � �� 6T   �� $  DataContext.ExecuteCommand�$
 self���� 5�   :    � �� 6]   �� *.+5�   3   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� *IsExecutable+$ PropertyChanged=�	) false6�   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) Execute6�   0�5�   6   �� 5�   :    �@ IsNotExecutable . 6\   5�   3   �� 5�   2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddTransition6�   .a�5�   6   ��  � {� .  6R   5�   3   �� 5�   2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddPlace6�   .a�5�   6   ��  � {� .  6R   5�   3   �� 5�   2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddConnection6�   .a�5�   6   ��  � �� 6P   �� $&  DataContext.AddConnectionCommand�$
 self���� 5�   6    � �� 6Y   �� *.+5�   3   �� 5�   2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� Edit6�   .a�5�   6   ��  � �� 6P   �� $ DataContext.EditCommand�$
 self���� 5�   6    � �� 6Y   �� *.+�� 5�   6    �@ IsShowInformation . 6Z   5�   3   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� $ IsMouseOver�( �� *Self+) true6�   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�
) Delete6�   0�5�   6   �� 5�   :    � �� 6T   �� $ DataContext.DeleteCommand�$
 self���� 5�   :    � �� 6]   �� *.+�� 5�   :    �@ IsMarkedAsDelete . 6]   5�   3   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� $ IsMouseOver�$ 
MainButton��) true6�   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   �� 5�   :   ' 6D   �� $, &DataContext.AddConnectionHelper.Source�$
 self��$ PropertyChanged=�8  ) true6�   0�5�   6   �� 5�   :    �@ IsMarkedAsSource . 6]   5�   3   ^� 5�   2   & 5�   6   �� 5�   :   ' 6D   �� $ IsMouseOver�$ 
MainButton��) true6�   �� 5�   :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   �� 5�   :   ' 6D   �� $, &DataContext.AddConnectionHelper.Source�$
 self��$ PropertyChanged=�8  	) false6�   �� 5�   :   ' 6D   �� $1 +DataContext.AddConnectionHelper.Destination�$
 self��$ PropertyChanged=�8  ) true6�   0�5�   6   �� 5�   :    �@ IsMarkedAsDestination . 6b   5�   3   5�   +   5�   '   5�   #   5      5     5     �� 5     "  6$   .R�5     �� $- 
MainBorder��6!   $��5q�65   $2 50��6I   ��5     �� 5  "   "	 ��6(    5  &   �� 5  *    66   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� Edit6�   .a�5	  .   ��  �@ IsDragSource . 6Y   5
  +   5  #   ._�5     � . 5  "   !� 5  &   / 62   �� $ 
BorderMain��.+�5  "   �� $- 
BorderMain��6P   8��    5  "   $0 
MainButton��6=   $3 50��6R   1 6d   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� 5  &   ���� 5  *   '        "	  60   8
  .�5  .   ��  � �� 5  2   �� 5  6   $��30��6b   $��30��6m   ��6C   �� *Points+��5  :   �� 5  >   .R�5  B   A� $��Stretch=�6N   $��Stretch=�6m   5  ?    5  :   ���� 5  >   "  6K   .R�5   B   � $��1q�6G   .+�5!  F   A� $��1��6�   ��6O   �� $ 
MainButton��$ 
Foreground���6�   �� $ 
MainButton��$ 
Foreground�6�   5"  C   5#  ?   5$  ;   5%  7   5'  /    5(  .   ^� 5)  2   & 5*  6   �� 5+  :   ' 6D   �� $ DataContext.EditorMode�$
 self��8  $4 Delete��	) False6�   �� 5,  :   ' 6D   �� $ DataContext.EditorMode�$
 self��8  $4 AddConnection��	) False6�   �� 5-  :   ' 6D   �� $ IsMouseOver�$ 
MainButton��) True6�   6�   0�5/  6   �� 50  :    � �� 51  >   �� 52  B   ��6L   �� *Name+$ PropertyChanged=�54  ;   57  3   �� 58  2    6>   �� *Points.Count+8  $4 9�� True6�   .a�59  6   ��  � �� 5:  :   �� 5;  >   $��18(�6f   ��6H   �� *Points.Count+6f   5=  7   5>  3   ^� 5@  2   & 5A  6   �� 5B  :   ' 6D   �� *SelectedAsSource+$ PropertyChanged=�) True6�   �� 5C  :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   0�5E  6   �� 5F  :    �@ IsMarkedAsSource . 6l   5I  3   �� 5K  2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� Execute6�   5M  3   �� 5O  2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddTransition6�   .a�5P  6   ��  � {� .  6R   5Q  3   �� 5S  2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddPlace6�   .a�5T  6   ��  � {� .  6R   5U  3   �� 5W  2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� AddConnection6�   .a�5X  6   ��  � �� 6P   �� $&  DataContext.AddConnectionCommand�$
 self���� 5Y  5    � �� 6X   �� *.+5Z  3   �� 5\  2    6>   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=� Edit6�   .a�5]  6   ��  � �� 6P   �� $ DataContext.EditCommand�$
 self���� 5^  6    � �� 6Y   �� *.+�� 5_  6    �@ IsShowInformation . 6Z   5`  3   ^� 5b  2   & 5c  6   �� 5d  :   ' 6D   �� $ IsMouseOver�( �� *Self+) true6�   �� 5e  :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�
) Delete6�   0�5g  6   �� 5h  :    � �� 6T   �� $ DataContext.DeleteCommand�$
 self���� 5i  :    � �� 6]   �� *.+�� 5j  :    �@ IsMarkedAsDelete . 6]   5l  3   ^� 5n  2   & 5o  6   �� 5p  :   ' 6D   �� $ IsMouseOver�$ 
MainButton��) true6�   �� 5q  :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   �� 5r  :   ' 6D   �� $, &DataContext.AddConnectionHelper.Source�$
 self��$ PropertyChanged=�8  ) true6�   0�5t  6   �� 5u  :    �@ IsMarkedAsSource . 6]   5w  3   ^� 5y  2   & 5z  6   �� 5{  :   ' 6D   �� $ IsMouseOver�$ 
MainButton��) true6�   �� 5|  :   ' 6D   �� $ DataContext.EditorMode�$
 self��$ PropertyChanged=�) AddConnection6�   �� 5}  :   ' 6D   �� $, &DataContext.AddConnectionHelper.Source�$
 self��$ PropertyChanged=�8  	) false6�   �� 5~  :   ' 6D   �� $1 +DataContext.AddConnectionHelper.Destination�$
 self��$ PropertyChanged=�8  ) true6�   0�5�  6   �� 5�  :    �@ IsMarkedAsDestination . 6b   5�  3   5�  +   5�  '   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     