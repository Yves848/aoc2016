$puzzle = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN"

$m = [regex]::Match($puzzle,"\((\d+)x(\d+)\)")
$M | ForEach-Object {
  $_
}
