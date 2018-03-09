@echo off
set destination="D:\Users\nfric\Documents\My Apps"
robocopy "D:\Users\nfric\Documents\Visual Studio 2017\Projects\Investimentos\Cotacoes\bin\Debug" %destination% /XO
robocopy "D:\Users\nfric\Documents\Visual Studio 2017\Projects\Investimentos\Investimentos\bin\Debug" %destination% /XO
robocopy "D:\Users\nfric\Documents\Visual Studio 2017\Projects\Investimentos\SerieHistorica\bin\Debug" %destination% /XO