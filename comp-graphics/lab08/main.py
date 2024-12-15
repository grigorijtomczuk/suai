from OpenGL.GL import *
from OpenGL.GLU import *
from OpenGL.GLUT import *

# Углы вращения для каждого объекта и группы
angle_group = 0.0
angle_cube = 0.0
angle_sphere = 0.0
angle_pyramid = 0.0

# Смещение куба вдоль Y
y_offset_cube = -3.0
is_y_descend_cube = False


# Функция для настройки OpenGL
def init():
    glClearColor(0.1, 0.1, 0.1, 1.0)  # Темный фон
    glEnable(GL_DEPTH_TEST)  # Включить тест глубины
    glEnable(GL_LIGHTING)  # Включить освещение
    glEnable(GL_LIGHT0)  # Источник света 0
    glEnable(GL_COLOR_MATERIAL)  # Включить использование цвета материалов
    glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE)  # Настройка материалов

    # Настройка света
    light_position = [1.0, 1.0, 1.0, 0.0]
    light_ambient = [0.2, 0.2, 0.2, 1.0]
    light_diffuse = [0.8, 0.8, 0.8, 1.0]
    light_specular = [1.0, 1.0, 1.0, 1.0]

    glLightfv(GL_LIGHT0, GL_POSITION, light_position)
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient)
    glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse)
    glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular)


# Функция для отображения сцены
def display():
    global angle_group
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT)  # Очистка экрана и буфера глубины
    glLoadIdentity()  # Сброс матрицы

    # Перемещаем камеру
    glTranslatef(0.0, 0.0, -15.0)

    # Групповое вращение всех объектов
    glRotatef(angle_group, 0.0, 1.0, 0.0)

    # Рисуем объекты
    draw_cube(angle_cube, y_offset_cube)
    draw_sphere(angle_sphere)
    draw_pyramid(angle_pyramid)

    glutSwapBuffers()  # Меняем буферы для двойной буферизации


# Функция для рисования куба
def draw_cube(angle, y_offset):
    glPushMatrix()
    glTranslatef(-3.0, y_offset, 0.0)  # Смещение куба влево
    glRotatef(angle, 1.0, 1.0, 0.0)  # Вращение куба вокруг собственной оси
    glColor3f(0.0, 1.0, 0.0)  # Зеленый цвет
    glutSolidCube(2.0)  # Рисуем куб размером 2
    glPopMatrix()


# Функция для рисования сферы
def draw_sphere(angle):
    glPushMatrix()
    glTranslatef(3.0, 0.0, 0.0)  # Смещение сферы вправо
    glRotatef(angle, 0.0, 1.0, 0.0)  # Вращение сферы вокруг своей оси
    glColor3f(1.0, 0.0, 0.0)  # Красный цвет
    glutSolidSphere(1.5, 50, 50)  # Рисуем сферу радиусом 1.5
    glPopMatrix()


# Функция для рисования пирамиды
def draw_pyramid(angle):
    glPushMatrix()
    glTranslatef(0.0, -3.0, 0.0)  # Смещение пирамиды вниз
    glRotatef(angle, 0.0, 1.0, 0.0)  # Вращение пирамиды вокруг своей оси
    glColor3f(0.0, 0.0, 1.0)  # Синий цвет
    glBegin(GL_TRIANGLES)

    # Передняя грань
    glVertex3f(0.0, 2.0, 0.0)
    glVertex3f(-1.0, 0.0, 1.0)
    glVertex3f(1.0, 0.0, 1.0)

    # Правая грань
    glVertex3f(0.0, 2.0, 0.0)
    glVertex3f(1.0, 0.0, 1.0)
    glVertex3f(1.0, 0.0, -1.0)

    # Задняя грань
    glVertex3f(0.0, 2.0, 0.0)
    glVertex3f(1.0, 0.0, -1.0)
    glVertex3f(-1.0, 0.0, -1.0)

    # Левая грань
    glVertex3f(0.0, 2.0, 0.0)
    glVertex3f(-1.0, 0.0, -1.0)
    glVertex3f(-1.0, 0.0, 1.0)

    glEnd()
    glPopMatrix()


# Функция для обработки изменения размера окна
def reshape(width, height):
    if height == 0:
        height = 1
    aspect = width / height

    glViewport(0, 0, width, height)
    glMatrixMode(GL_PROJECTION)
    glLoadIdentity()
    gluPerspective(45.0, aspect, 0.1, 50.0)
    glMatrixMode(GL_MODELVIEW)
    glLoadIdentity()


# Функция для обновления углов вращения
def update(value):
    global angle_group, angle_cube, angle_sphere, angle_pyramid, y_offset_cube, is_y_descend_cube

    # Обновляем углы вращения
    angle_group += 1.0
    angle_cube += 2.0
    angle_sphere += 1.5
    angle_pyramid += 1.0

    if angle_group > 360:
        angle_group -= 360
    if angle_cube > 360:
        angle_cube -= 360
    if angle_sphere > 360:
        angle_sphere -= 360
    if angle_pyramid > 360:
        angle_pyramid -= 360

    # Обновляем смещение куба по Y
    if y_offset_cube >= 3.0:
        is_y_descend_cube = True
    if y_offset_cube <= -3.0:
        is_y_descend_cube = False

    if is_y_descend_cube:
        y_offset_cube -= 0.05
    else:
        y_offset_cube += 0.05

    glutPostRedisplay()
    glutTimerFunc(16, update, 0)


# Главная функция
def main():
    glutInit()
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH)
    glutInitWindowSize(800, 600)
    glutCreateWindow("3D Сцена")
    glutDisplayFunc(display)
    glutReshapeFunc(reshape)
    glutTimerFunc(0, update, 0)
    init()
    glutMainLoop()


if __name__ == "__main__":
    main()
