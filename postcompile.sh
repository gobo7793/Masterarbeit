#!bin/bash
# commands to execute after compilation
# settings for TeXstudio: https://tex.stackexchange.com/a/261721
datetime=$(date "+%F %T")

git add --all \
	 && git commit -m "autosave $datetime" \
	 && git push
