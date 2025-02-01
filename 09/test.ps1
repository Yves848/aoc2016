$puzzle = Get-Content -Path "data.txt"

while ($puzzle -ne "") {
  $m = [regex]::Match($puzzle,"\((\d+)x(\d+)\)")
  $temp = $puzzle.Substring(0,$m.Groups[1].Value+$m.Length)
  $puzzle = $puzzle.substring($m.Index+$m.Length+$m.Groups[1].Value+$m.Length)
  Write-Host "$temp"
}