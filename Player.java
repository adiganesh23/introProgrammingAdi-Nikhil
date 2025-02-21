package entity;

import java.awt.Color;

import main.GamePanel;
import main.KeyHandler;


public class Player extends entity{
    GamePanel gp;
    KeyHandler keyH;
    public Player(GamePanel gp, KeyHandler keyH) {
        this.gp = gp;
        this.keyH = keyH;
        setDefeaultValues();
    }
    public void setDefeaultValues() {
        x = 100;
        y = 100;
        speed = 4;
    }
    public void update() {
        if (keyH.upPressed) {
            y -= speed;
        }
        else if (keyH.downPressed) {
            y += speed;
        }
        else if (keyH.rightPressed) {
            x += speed;
        }
        else if (keyH.leftPressed) {
            x -= speed;
        }
    }
    public void draw(java.awt.Graphics2D g2) {
        g2.setColor(Color.white);

        g2.fillRect(x,y,gp.tileSize,gp.tileSize);
    }

}
