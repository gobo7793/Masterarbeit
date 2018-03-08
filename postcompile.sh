#!bin/bash
# commands to execute after compilation
# settings for TeXstudio: https://tex.stackexchange.com/a/261721
datetime=date "+%x %X"

git add --all \
	 && git commit -m "autosave $datetime" \
	 && git push
