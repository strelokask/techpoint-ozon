$RED = [ConsoleColor]::Red
$GREEN = [ConsoleColor]::Green

if ($args.Count -ne 1) {
    Write-Host "Usage: $PSCommandPath <project path>" -ForegroundColor $RED
    exit 1
}

$project_path = $args[0]

if (-not (Test-Path $project_path -PathType Container)) {
    Write-Host "Project folder $project_path doesn't exist" -ForegroundColor $RED
    exit 1
}

dotnet build "$project_path"

$exe_path = Get-ChildItem "$project_path" -Filter "$project_path.exe" -Recurse

if (-not $exe_path) {
    Write-Host "Failed to find executable for project $project_path" -ForegroundColor $RED
    exit 1
}

$test_path = Get-ChildItem "$project_path\tests\*.a" | Sort-Object { [int]($_.BaseName) }
$total_tests = $test_path.Count

if ($total_tests -eq 0) {
    Write-Host "No tests found in $(Get-Location)\tests\" -ForegroundColor $RED
    exit 1
}

foreach ($file in $test_path) {
    if (Test-Path $file) {
        $input_file = $file.FullName -replace '\.a$'
        $test_num = [System.IO.Path]::GetFileNameWithoutExtension($input_file)
        $test_name = "Test $test_num"
        if((Get-Content $input_file | & $exe_path.FullName | Out-String) -ne (Get-Content $file.FullName | Out-String)){
            Write-Host "FAIL $test_name" -ForegroundColor $RED
            exit 1
        }
        else{
            Write-Host "PASS $test_name / $total_tests" -ForegroundColor $GREEN
        }
    }
}
