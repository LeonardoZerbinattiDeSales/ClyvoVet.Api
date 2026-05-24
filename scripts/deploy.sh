#!/bin/bash

git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git

cd SEU_REPOSITORIO

docker compose up -d --build

echo "Aplicação publicada!"