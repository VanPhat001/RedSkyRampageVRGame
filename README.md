[db.sql](./Assets/_MyAsset/Diagram/db.sql) <br>
[db.drawio](./Assets/_MyAsset/Diagram/info.drawio) <br>
![db image](./Assets/_MyAsset/Diagram/db%20image.png) <br>

# Todo List

- [x] Tạo repo github
- [x] Tự động phân chia server và client dựa theo thiết bị
- [x] Tự động reconnect khi bị lỗi
- [x] Server kết nối MySQL
- [x] Game object `NetworkCommunication`
  - [x] Spawn
  - [x] Auth Player RPC
- [x] `ClientSpawnedObjectManager`
- [x] Serialize Dictionary
- [x] Room Manager
- [x] Object Pool
- [x] Finite State Machine
- [ ] Abstract Class
  - [x] `BaseLayout.cs`
  - [x] `BaseGun.cs`
- [ ] Interface
  - [x] `IDamageable.cs`
  - [ ] `IHealable.cs`
- [ ] DTO
- [ ] `VR Character`
- [ ] Multiplayer Scene
  - [ ] Thiết kế
- [ ] Singleplayer Scene
  - [x] Điều hướng đến Map Level Scene (Load Additive)
  - [x] `level1scene`
  - [ ] `level2scene`
- [ ] Map Level Scene
  - [x] Điều hướng từ ClientScene (Load Additive)
  - [x] Điều hướng về ClientScene (Unload)
  - [x] Tích hợp map
  - [ ] Fetch thông tin map
- [ ] Zombie Detail Scene
  - [x] Điều hướng từ ClientScene (Load Addtive)
  - [x] Điều hướng về ClientScene (Unload)
  - [ ] Hiển thị thông tin zombie
  - [ ] Hiển thị model zombie
- ~~[ ] Change Skin Scene~~
  - ~~[ ] Điều hướng từ ClientScene (Load Addtive)~~
  - ~~[ ] Điều hướng về ClientScene (Unload)~~
  - ~~[ ] Fetch thông tin trang phục~~
  - ~~[ ] Tạo Game Object gương~~
  - ~~[ ] API thay đổi trang phục ==> Trang phục này dùng ở đâu?~~
- [ ] Hệ thống bạn bè
  - [ ] Gửi lời mời kết bạn
  - [ ] Mời tham gia phòng chờ
- [ ] Emeny
  - [x] `War Zombie`
  - [ ] `Zombie Girl`
- [ ] Bullet
  - [x] Local Bullet
  - [ ] Network Bullet
- [ ] Occlusion Culling
  - [x] Level 1
  - [ ] Level 2
- [x] Network Visibility
- [x] Teleport Player thông qua `XR Origin`

<br>
<br>

# Thiết kế map

### MAP LEVEL 1 - HƯỚNG DẪN TÂN THỦ

Bối cảnh:
  - Một phòng nghiên cứu về vũ khí sinh học
  - Nghiên cứu thất bại
  - Virus phát tán trong khu vực
  - Virus khiến những xác chết biến thành zombie

- [ ] Mission 1
  - [x] Di chuyển đến vị trí vũ khí
  - [x] Nhặt vũ khí
  - [x] Hướng dẫn bóp cò
  - [x] Hướng dẫn nạp đạn
- [ ] Mission 2
  - [x] Tiêu diệt 3 zombie -> Rớt thư
- [ ] Mission 3
  - [ ] Nhặt mission item (thư)
  - [ ] Đi đến vị trí chỉ định
  - [ ] Kết thúc

<br>

---

### MAP LEVEL 2 - BẢO VỆ CỨ ĐIỂM

Bối cảnh: 
  - Đang liên lạc với bộ phận chỉ huy
  - Zombie tràn đến
  - Bị nhiễu kết nối với bộ phận chỉ huy
  - Tìm `flare gun`
  - Bắn `flare gun` LÊN BẦU TRỜI
  - Cutscene -> Máy bay tiếp viện đến thả bom
  - Kết thúc

- [ ] Main Mission
  - [ ] Sống sót
  - [ ] Phòng thủ cứ điểm
- [ ] Sub Mission 1
  - [ ] HP >= 50%
- [ ] Sub Mission 2
  - [ ] Tiêu diệt ít nhất 4 zombie
- [ ] Sub Mission 3
  - [ ] Hidden Item: `flare gun`

<br>
<br>

# Error List
- Check lại âm thanh ở level1scene, phát xong nhưng k enalbed=false gameobject
  - Lỗi mạng
  - Lỗi code