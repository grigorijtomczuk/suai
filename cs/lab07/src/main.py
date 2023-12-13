# 20. Разработать систему, реализующую CRUD операции с базой данных книжного магазина.

import json

from controllers import entries

format_json = lambda obj: json.dumps(obj, indent=2, ensure_ascii=False)

while True:
  operation = input("Выберите операцию: ")

  match operation:
    case "1":
      print(format_json(entries.get_all()))
    case "2":
      id = int(input("Введите ID: "))
      print(format_json(entries.get_one_by_id(id)))
    case "3":
      entries.create_one({
        "name": "Тест Тест",
        "courses_id": [1, 2],
        "contacts": {
          "email": "тест@example.com",
          "phone": "+333333",
        },
      })
    case "4":
      id = int(input("Введите ID: "))
      print(format_json(entries.update_one_by_id(id, {
        "name": "Не Смирнова Екатерина",
        "contacts": {
          "email": "нет@example.com",
          "phone": "+1122334455",
        },
      })))
    case "5":
      id = int(input("Введите ID: "))
      print(format_json(entries.delete_one_by_id(id)))
