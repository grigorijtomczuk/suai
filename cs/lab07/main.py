# 20. Разработать систему, реализующую CRUD операции с базой данных книжного магазина.

import json

from components.teachers import service as teacher

format_json = lambda obj: json.dumps(obj, indent=2, ensure_ascii=False)

operation = input("Выберите операцию: ")

match operation:
  case "1":
    print(format_json(teacher.get_all()))
  case "2":
    print(format_json(teacher.get_one_by_id(1)))
  case "3":
    teacher.create_one({
      "name": "Тест Тест",
      "courses_id": [1, 2],
      "contacts": {
        "email": "тест@example.com",
        "phone": "+333333",
      },
    })
  case "4":
    print(teacher.update_one_by_id(4, {
      "name": "Не Смирнова Екатерина",
      "contacts": {
        "email": "нет@example.com",
        "phone": "+1122334455",
      },
    }))
  case "5":
    print(teacher.delete_one_by_id(4))
