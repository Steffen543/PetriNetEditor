   M S B A M L   `   `   `  ����G  CPetri.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Petri.EditorPetri.Editor  5   	   ;"clr-namespace:Petri.Editor.UI.ViewPetri.Editor.UI.View  5   	   E'clr-namespace:Petri.Editor.UI.ViewModelPetri.Editor.UI.ViewModel  5   	   ?$clr-namespace:Petri.Editor.ConverterPetri.Editor.Converter  5	   	       Petri.Editor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=18.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Petri.Editor     5   	   3view"clr-namespace:Petri.Editor.UI.View     5   	   =	viewModel'clr-namespace:Petri.Editor.UI.ViewModel     5   	   :	converter$clr-namespace:Petri.Editor.Converter     5	   	     � WindowState$  	Maximized=�5
      $	��750��5   	   $
��1200��6    � 	Resources 5      ,  &Petri.Editor.Converter.IsNullConverter   IsNullConverter��%   &	          5   
   6$   5      ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@�Title �� Value$ Petri-Netz Editor��6&    �� Triggers 5      �� 5       �� Binding 6   �� *	IsSaved+ �� UpdateSourceTrigger$ PropertyChanged=� �� Value True6_   .a�5      ��  �@�Title 6.   �� *CurrentFileName+5      ^� 5      	 ^� 
Conditions	 5      �� 5      
 �� Binding
 6$   �� *	IsSaved+$ PropertyChanged=� �� Value	 False6e   �� 5      
 6$   �� *CurrentPnmlNet+ �� 	Converter# [  	 False6s   0�5      �� 5       �@�Title$  Ungespeichertes Petri-Netz��62   6W   5      5        J� InputBindings 5"      �� 5#   
    �� 	Modifiers$
 Ctrlf�6   
 �� Key$ S��6&    �� Command 6.   �� *SavePetriNetCommand+�� 5$   
   $ Escape��6    6"   �� *EditorViewModel.CancelCommand+ � DataContext 5&      3  -Petri.Editor.UI.ViewModel.MainWindowViewModel  5'   
   .��5)      �  � RowDefinitions 5*   
   �� 5+      $
��Auto �6   �� 5,      $��* �6   .+�5.   
   o� $��0��6   .@�50      m� $��Datei��6   .@�51      m� $	��Neu��6    m� Command 6(   �� *CreateNewPetriNetCommand+m� 52      $��Öffnen��6    6+   �� *OpenPetriNetFileCommand+m� 53      $��	Speichern��6    6.   �� *SavePetriNetCommand+m� 54      $��Speichern unter��6    64   �� *!SavePetriNetUnderNewNameCommand+55      56      -   'Petri.Editor.UI.View.PetriNetEditorView  57   
   -   5          Name$ PetriEditor��57   "   $��1��6Q    67   �� *.+6Q   58      59      