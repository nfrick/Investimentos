@echo off
set destination="D:\My Apps"
robocopy "F:\Users\Nelson\Documents\Visual Studio 2017\Projects\Investimentos\Cotacoes\bin\Debug" %destination% /XO
robocopy "F:\Users\Nelson\Documents\Visual Studio 2017\Projects\Investimentos\Investimentos\bin\Debug" %destination% /XO
robocopy "F:\Users\Nelson\Documents\Visual Studio 2017\Projects\Investimentos\SerieHistorica\bin\Debug" %destination% /XO