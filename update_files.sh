#!/bin/bash

# Move the new files to replace the original ones
mv -f App.xaml.new App.xaml
mv -f MauiProgram.cs.new MauiProgram.cs
mv -f MainPage.xaml.new MainPage.xaml
mv -f MainPage.xaml.cs.new MainPage.xaml.cs
mv -f Resources/Styles/TaskItemTemplate.xaml.new Resources/Styles/TaskItemTemplate.xaml

echo "Files updated successfully!"
