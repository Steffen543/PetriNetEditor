   M S B A M L   `   `   `  ����G  CPetri.Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Petri.Editor.UI.ViewPetri.Editor.UI.View  5      ,    &Petri.Editor.UI.View.EmptyPetriNetView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=18.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Petri.Editor.UI.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5          >�Name$
  self��5	      ���#A0A0A0.��5      �� $��75q�6   .+�5   
   �� $��30(�6   $ ��Öffnen Sie ein Petri Netz��6"   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6   $��5q�6    $
��Neu.��6,   ��6;   �� *CreateNewPetriNetCommand+�� 5      $��5q�6   $��5q�6    $��	Öffnen..��6,   ��6?   �� *OpenPetriNetFileCommand+5      �� 5   
   $��Zuletzt geöffnet��6   $��14(�6,   6<   �� 5   
   
������ $��0q�6S   ��6   �� *LastOpenedFiles+��5      �� 5      .R�5      � .+�5      �� .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   "      	EventName$ MouseLeftButtonUp��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *)'DataContext.OpenLastPetriNetFileCommand+ �� ElementName$
 self��   CommandParameter 6�   �� *.+5   #   ��5      �� 5   "    �� 
TargetType" ��6(   .�5   &   �� 	 �� Property	 � ��
 �� Value
 6=   ��  �� Path$ FileName��� 5   &   	 � ��
 �#00597A6C   �� 5    &   	 � ��$

 Bold"�6C   �� 5!   &   	 �@�Cursor$

 Hand��6?    �� Triggers 5"   &   �� 5#   *    �� Binding 66   �� $ IsAvailable� �� Value	 False6[   .a�5$   .   �� 	 � ��
 �#6060606K   �� 5%   .   	 �@�Cursor$
 Arrow��6G   5&   +   5(   #   5*      5-      5.       � 	Resources 50       �� 
TargetType �� CornerRadius��%�   '��       �� 51      " ��6   .�52      �� 	 � ��
 53      �� 54      " ��6.   .R�55   "   �� $��Border��6)   $��1q�56   )   $ 2��57   )   ._�59   &   �� 5:   #   5;   #   5=      5>      5?      5@      5A      5B      