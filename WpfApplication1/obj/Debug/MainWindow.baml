   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   G(clr-namespace:WpfApplication1.ViewModelsWpfApplication1.ViewModels  5   	   G(clr-namespace:WpfApplication1.ConvertersWpfApplication1.Converters  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	   >	viewModel(clr-namespace:WpfApplication1.ViewModels     5   	   ?
converters(clr-namespace:WpfApplication1.Converters     5   	     � Title$  ImagesWindow��5   	   $	��350��6   $	��525��6+    � DataContext 5      /  )WpfApplication1.ViewModels.ImageViewModel  5	   
    � 	Resources 5      /   )WpfApplication1.Converters.ImageConverter   	converter/   )WpfApplication1.Converters.ColorConverter  colorConverter0   *WpfApplication1.Converters.HeightConverter  heightConverter  FileNameTopTemplate �� RelativeSource �� AncestorType � RowDefinitions �� StretchDirection �� Path �� 	Converter	 �� Padding  FileNameBottomTemplate  TemplateSelector
 �� Triggers �� Value �� Binding �� ElementName �� 
TargetName �� Value �� Property��%_  &	        &	      &	 &     &	 9     7   &	 �    7   7  7  &	 s    7  7    5   
   6$     5   
   6$     5   
   6%   �� 5   
   .R�5      � ��6   �� *ActualWidth+ �� " ����6y   �� *ActualHeight+ �� " �� 5      �� 5      6&   �� 5      6&   .+�5      �� $
 Both=�6   $��UniformToFill=�60   $��0��6I   $��2��6V   ��6g   �� $
 Path�8   6�   �� 5      $��0��68   $	 5 5 0 0q�6E   ��6   �� $ Title�6Y   5      5      �� 5   
   .R�5      �� ��6   �� *ActualWidth+ �� " ����6{   �� *ActualHeight+ �� " ��.+�5      �� $��	-5 30 0 0q�6   $
 Both=�6+   $��UniformToFill=�6C   ��6\   �� $
 Path�8   ��6�   �� *ActualWidth+ �� " ����6  �� *ActualHeight+8   �� " ��6�  �� 5      $	 5 5 0 0q�6�   ��6   �� $ Title���68   �� $ Title�8  6�   5      5      �� 5   
   .R�5       �� $��contentPresenter��63   ��6   �� 63   
 5!      �� 5"      $ Advanced��6[    6   �� $ comboBox��$ SelectedValue�.a�5#      �� $ contentPresenter��6   8    � ��6V   5$      �� 5%      $ Common��6[    6   �� $ comboBox��$ SelectedValue�.a�5&      �� $ contentPresenter��6   8   � ��6V   5'      5)      5*      .��5+      �  5,   
   �� 5-      $��60 �6   6*   �� 5.      6    � ColumnDefinitions 50   
   �� 51      $	��120 �6   6-   �� 52      $	��140 �6   6-   �� 53      6!   .+�55   
   �� $	��100��6   $��30��6   $��5q�6)   $
��Left=�64   ��6O   �� *StartCommand+.��56      �� -   5        $��ButtonImage��56      ��57      �� 58       �� 
TargetType" ��6    �� Triggers 59      �� 5:       6*   �� *	IsPlaying+	 False6H   .a�5;   "   ��  � ��$ Images/Play.png��6;   5<      �� 5=       6*   �� *	IsPlaying+ True6H   .a�5>   "   ��  � ��$ Images/Pause.png��6;   5?      5A      5C      5D      �� 5E   
   -   5        $��comboBox��5E      $��1��6#   $	��120��63   $��30��6?   ��6K   �� *TemplateTypes+ �� SelectedItem 6q   �� *SelectedType+6�   �� 5F   
   $��2��6    � Minimum$ 0Q�6!    �� TickFrequency$ 10Q�6-    � Maximum$
 1000Q�6@   $��Center=�6j    � Value 6O   �� *
Interval+6�   �� 5G   
   -   5        $��lb��5G   C   #��[ 6   $��Disabled=�6M   $��Disabled=�6�   $��1��6�   $��3��6�   ��6�   �� *Images+��5H      �� 5I      .R�5J      A�  A� Columns 6"   �� *DirectoriesCount+6I   5K      5M      5N      5O      