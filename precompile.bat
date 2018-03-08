REM commands to execute before tex compilation
git pull

REM copy files from ssharp repo
xcopy "..\ssharp\Models\TestingHadoop\YarnModel.png" "images\yarnModel.png*" /d /y
