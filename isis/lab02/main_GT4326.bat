@echo off

rd /S /Q All\A3\B3
md All\A1\B4
md All\A1\B5
rd /S /Q All\A2\B2

copy All\first.txt All\A2\
ren All\A2\first.txt one.txt

copy All\*txt All\A2\B1\C2\

type All\A2\B1\C2\*.txt > All\A2\B1\C2\man_GT4326.txt
type All\A2\B1\C2\man_GT4326.txt

copy All\A2\B1\C2\man_GT4326.txt All\