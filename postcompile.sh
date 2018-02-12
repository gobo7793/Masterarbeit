#!bin/bash
# commands to execute after compilation
# settings for TeXstudio: https://tex.stackexchange.com/a/261721

git add --all
git commit -m "autosave %date%-%time:~0,8%"
git push
