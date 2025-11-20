#!/bin/bash
rm -f ./Infrastructure/Data/Migrations/*
rm -f ./tpi-GasparOneto-2024-programacion3/*.db
rm -f ./tpi-GasparOneto-2024-programacion3/*.db-shm
rm -f ./tpi-GasparOneto-2024-programacion3/*.db-wal
dotnet ef migrations add InitialMigration --context ApplicationDbContext --startup-project tpi-GasparOneto-2024-programacion3 --project Infraestructure -o Data/Migrations -- --environment development
dotnet ef database update --context ApplicationDbContext --startup-project tpi-GasparOneto-2024-programacion3 --project Infraestructure -- --environment development
