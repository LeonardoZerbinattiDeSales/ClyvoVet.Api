#!/bin/bash

sudo apt update -y

sudo apt install -y docker.io docker-compose git nano

sudo systemctl start docker

sudo systemctl enable docker

sudo usermod -aG docker $USER

echo "Docker instalado com sucesso!"