   M S B A M L   `   `   `  ����E  ABinanceNFT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BinanceNFT.ViewModelsBinanceNFT.ViewModels  5      9!clr-namespace:BinanceNFT.ControlsBinanceNFT.Controls  5      =#clr-namespace:BinanceNFT.ConvertersBinanceNFT.Converters  5      3clr-namespace:BinanceNFT.ViewsBinanceNFT.Views  5	      5clr-namespace:BinanceNFT.ModelsBinanceNFT.Models  5
      !    BinanceNFT.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      :
viewModels#clr-namespace:BinanceNFT.ViewModels     5      6controls!clr-namespace:BinanceNFT.Controls     5      :
converters#clr-namespace:BinanceNFT.Converters     5      0viewsclr-namespace:BinanceNFT.Views     5	      2modelsclr-namespace:BinanceNFT.Models     5
      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5        � WindowStyle$
  None=�5       � AllowsTransparency .  � 
ResizeMode$ 	CanResize=�5       � WindowStartupLocation$ CenterScreen=�5      $	��750��5      $
��1200��5      ��5      �� *WindowMinimumWidth+��5      �� *WindowMinimumHeight+ � 	Resources 5      5   /BinanceNFT.Converters.BoolToVisibilityConverter   BoolToVisibilityConverter 	 Boxes �� Source �� Path!   BinanceNFT.Views.MainWindow �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� Padding �� FallbackValue ��Name  BackgroundLightBrush �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions K� ZIndex � ColumnDefinitions  	Hoverless  
HeaderText �� Orientation  WindowControlButton  IconMinimize  IconMaximize  WindowCloseButton 	 IconExit �� Color �� Opacity��%�  &	        &	      '  ?     7  7  7  7  7  7  7  7  7 	   5      6)   �� 5       5   
   �� $ Boxes��� 5      "  6
   .�5      ��  � ��	 5      �� 5      "
 �6   .R�5      ��  6   �� *OuterMarginSizeThickness+$ 5��._�5    	   � .+�5!   
   �� $ 	Container��6   8��   5#      �� *WindowCornerRadius+$ 0���� 5%   
    6   �� *WindowCornerRadius+$ 0����5&      �� *ForegroundLightBrush+$ White�� 5'        5(      $ 0Q�6   $	 0.2Q�5)      5+      � 5-   
    5.      !� 5/       6   �� $ 	Container�� 52      �� 53      ��6   �� *TitleHeightGridLength+$ 40���� 54      $
��Auto �6   �� 55      $��* �6   .+�58      � $��0��6   $ 1��59       5:      �� 5;      $
��Auto �6   �� 5<      $��* �6   .+�5?      �� $��0��6   8�� ��5A      �� *MenuCommand+.��5B      �� 8�� $��Binance NFT Manager��5C      $
��Auto��5D      5E      �� 5G      $��1��6   $ 
Horizontal=�5H      $��Right=�5I      .+�5J      �� $��
10,15,10,0q�5K      8�� ��5J      �� *MinimizeCommand+.��5M      �� 8�� 6   5N      �� 5O      $��	10,4,10,0q�5P      8�� ��5O      �� *MaximizeCommand+.��5R      �� 8�� 6   5S      �� 5T      8�� ��6   �� *CloseCommand+.��5V      �� 8�� 6   5W      5X      5Z      �� 5[      $��1��6   $��6��5\      $��0 1 0 0q�5]      ��5^      �� 5_      $ Black��6   $
 0.05Q�5`      5b      �� 5d      $��2��6    5e      �� *InnerContentPadding+._�5f      �� #��z��6   5g      5h      5i   
   5j   	   5k      5m      5n      5o      '  !System.Windows.Shell.WindowChrome   WindowChrome 5q        5r         CornerRadius$ 0��5t         GlassFrameThickness$ 0q�5u         ResizeBorderThickness 5r      �� *ResizeBorderThickness+   CaptionHeight 5s      �� *TitleHeight+5u      .��5x      �  5y      �� 5z      $
��Auto �6   �� 5{      $��* �6   .+�5}      �� $��0��6   $
��1000��5~      $	��175��5      $��0,20,0,0q�5�      $��Center=�5�      ��5�      �� 5�      .R�5�      ��  
 CustomButtonStyle#��[
 6   
������ 
���   �
���   �$	��1.5q�5�      ��5�      �� $, &DataContext.MysteryBoxSelectionCommand�  �� RelativeSource  �� *FindAncestor+! �� AncestorType$! views:MainWindowL���5�      �� ��5�      �� *Name+5�      5�       5�      ��%�  (��       5�      * SystemColors.HighlightBrushKey+)(�� )     5�      *$"SystemColors.HighlightTextBrushKey+)(�� L     5�      *SystemColors.ControlBrushKey+)(�� u     5�      *1/SystemColors.InactiveSelectionHighlightBrushKey+)�� 5�      $ Transparent��5�   
   �� 5�      $ Black��5�   
   �� 5�      $ Transparent��5�   
   �� 5�      $ Transparent��5�   
   5�      ��5�      �� 5�      .R�5�      �� " ��Name$" ScrollViewer��6   $
��Auto=�5�      $��Disabled=�5�      ��.   ScrollViewerStyle#��[ 5�      .��5�      �� 5�      5�      ��5�      -  'System.Windows.Data.CompositeCollection  5�      �� 5�      # �� 
Collection# 6   �� $ �� Source#$ [ �� 5�      $��	Show more��5�      #��[
 5�      
����  �
������ $��0q�5�      
���������5�      �� *ShowMoreBoxesCommand+y�5�      �� *ShowMoreBoxesFeature+% �� 	Converter#% [  5�      5�      ��5�      �� 5�      .R�5�      ,   &BinanceNFT.Controls.AlignableWrapPanel  !&   HorizontalContentAlignment$& Center=�6#   5�      5�      5�      5�      