#!/bin/bash

RESOURCE_GROUP="rg-clyvovet"
LOCATION="eastus"
VM_NAME="vm-clyvovet"
USERNAME="azureuser"

az group create \
  --name $RESOURCE_GROUP \
  --location $LOCATION

az vm create \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --image Ubuntu2204 \
  --admin-username $USERNAME \
  --generate-ssh-keys \
  --size Standard_B1s

az vm open-port \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --port 80

az vm open-port \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --port 8080

echo "VM criada com sucesso!"